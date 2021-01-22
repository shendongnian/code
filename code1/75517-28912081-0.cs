    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new event EventHandler TextChanged
    {
        add { base.TextChanged += value; }
        remove { base.TextChanged -= value; }
    }
