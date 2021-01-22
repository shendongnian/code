    public event EventHandler<HelpTextEventArgs> HelpTextRequested;
    
    protected void OnHelpTextRequested(HelpTextEventArgs e)
    {
        EventHandler<HelpTextEventArgs> evt = this.HelpTextRequested;
        if (evt != null)
        {
            evt(this, e);
        }
    }
    // wrapper for the event raising method for easier access in the code
    public string GetHelpText(string fieldId)
    {
        HelpTextEventArgs e = new HelpTextEventArgs(fieldId);
        OnHelpTextRequested(e);
        return e.Text;
    }
