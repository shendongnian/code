    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        Opacity = 1;
    }
    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        Opacity = 0;
    }
