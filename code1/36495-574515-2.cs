    public event EventHandler AdvancedClick;
    private void lbtnAdvanced_Click(object sender, EventArgs e)
    {
        OnAdvancedClick(e);
    }
    protected void OnAdvancedClick(EventArgs e)
    {
        if (AdvancedClick != null)
            AdvancedClick(this, e);
    }
