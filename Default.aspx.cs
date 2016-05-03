using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BookReviewServiceReference.SampleBookReviewServiceClient bsc
        = new BookReviewServiceReference.SampleBookReviewServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            FillAuthorDropDown();
    }

    protected void FillAuthorDropDown()
    {
        string[] authors = bsc.GetAuthors();
        AuthorDropDownList.DataSource = authors;
        AuthorDropDownList.DataBind();
    }

    protected void BookButton_Click(object sender, EventArgs e)
    {
        string author = AuthorDropDownList.SelectedItem.Text;
        BookReviewServiceReference.BookLite[] books= bsc.GetBooks(author);
        BookGridView.DataSource = books;
        BookGridView.DataBind();
    }
}