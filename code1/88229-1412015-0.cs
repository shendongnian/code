    protected void btnDone_Click(object sender, EventArgs e)
    {
        LoadPostBackData();
        // do your other stuff
    }
    
    // loads the values posted to the page via form postback to the actual controls
    private void LoadPostBackData()
    {
        LoadPostBackDataItem(this.txtYear);
        LoadPostBackDataItem(this.txtDate);
        // put other items here if needed
    }
    
    // loads the values posted to the page via form postback to the actual controls
    private void LoadPostBackDataItem(TextBox control)
    {
        string controlId = control.ClientID.Replace("_", "$");
        string postedValue = Request.Params[controlId];
        if (!string.IsNullOrEmpty(postedValue))
        {
            control.Text = postedValue;
        }
        else
        {
            control.Text = null; // string.Empty;
        }
    }
