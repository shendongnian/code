    private void Page_Load(object sender, EventArgs e)
    {
        ServerControl.HelpTextRequested += ServerControl_HelpTextRequested;
    }
    
    private void ServerControl_HelpTextRequested(object sender, HelpTextEventArgs e)
    {
        e.Text = FindHelpText(e.FieldId);
    }
