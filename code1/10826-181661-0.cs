    if (Page.PreviousPage != null)
    {
        TextBox SourceTextBox = 
            (TextBox)Page.PreviousPage.FindControl("TextBox1");
        if (SourceTextBox != null)
        {
            Label1.Text = SourceTextBox.Text;
        }
    }
