    public WpfToggleButton PendingButton
    {
        get
        {
            if ((this.mPendingButton == null))
            {
                this.mPendingButton = new WpfToggleButton( ... as needed ...);
                this.mPendingButton.SearchProperties[ ... as needed ...] = ... as needed ...;
            }
            return this.mPendingButton;
        }
    }
    private WpfToggleButton mPendingButton;
