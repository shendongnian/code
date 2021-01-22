    // This event will be handled by the webform
    public event EventHandler OkButtonClicked;
    protected void btnOk_Click(object sender, EventArgs e)
    {
        // Raise the okButtonClicked event
        if (OkButtonClicked != null)
           OkButtonClicked(sender, e);
    }
    // The btnOk button will be wired to our new event handler
    btnOk.Click += new ImageClickEventHandler(btnOk_Click);
