    if (Page.PreviousPage != null)
    {
        TextBox SourceTextBox = 
            (TextBox)Page.PreviousPage.FindControl("txtInfo");
        if (SourceTextBox != null)
        {
            Label1.Text = SourceTextBox.Text;
        }
    }
