    private bool IsFlashing;
    ....
    // Code for IM windows
    public void OnActivate(EventArgs e)
    {
        if (IsFlashing)
        {
            // stop flash
            IsFlashing = false;
        }
    }
    public void Flash()
    {
        // make flash
        IsFlashing = true;
    }
