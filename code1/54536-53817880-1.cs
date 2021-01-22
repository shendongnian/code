    ///This method is save the actual position of the window to file "WindowName.pos"
    private void ClosingTrigger(object sender, EventArgs e)
    {
        this.SavePlacement();
    }
    ///This method is load the actual position of the window from the file
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        this.ApplyPlacement();
    }
