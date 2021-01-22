    private Size maxSize = new Size(100, 5);
    public override Size MaximumSize
    {
        get { return base.MaximumSize; }
        set { base.MaximumSize = maxSize; }
    }
