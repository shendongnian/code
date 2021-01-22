    if (Validation())
    {
        if (DoSaveFunction())
        {
             Response.Redirect("theNextPage.aspx");
        }
        else
        {
             lblWarning.Text = "Something went wrong saving the file";
        }
    }
    else
    {
        lblWarning.Text = "Invalid inputs";
    }
    
