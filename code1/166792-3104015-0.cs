    private void SomewhereElse()
    {
       UpdatePreview(null, new EventArgs());
    }
    private void UpdatePreview(object sender, EventArgs e)
    {
        if (sender == null) 
        {
            txtPreview.Text = "The user has changed one of the options!";
        }
    }
