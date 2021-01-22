    private volatile bool _formVisible;
    protected override void SetVisibleCore(bool value)
    {
        base.SetVisibleCore(_formVisible);
    }
    public void ShowForm()
    {
        _formVisible = true;
        if (InvokeRequired)
        {
            Invoke((Action) Show);
        }
        else
        {
            Show();
        }
    }
