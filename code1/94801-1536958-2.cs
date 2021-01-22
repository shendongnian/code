    protected void Page_Load(object sender, EventArgs e)
    {
        Button theButton;
        if (Request.Form.AllKeys.Contains("button1"))
            theButton = button1;
        else if (Request.Form.AllKeys.Contains("button2"))
            theButton = button2;
        ...
    }
