    // if the ID is constant you can use this:
    /*TextBox textBox = (TextBox)Page.Controls[0]
                                    .FindControl("ContentPlaceHolder1")
                                    .FindControl("myTextBox");
    */
    // this will look for the 1st textbox without hardcoding the ID
    TextBox textBox = (TextBox)Page.Controls[0]
                                .FindControl("ContentPlaceHolder1")
                                .Controls.OfType<TextBox>()
                                .FirstOrDefault();
    if (textBox != null)
    {
        textBox.Focus();
    }
