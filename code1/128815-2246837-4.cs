    protected void OnImageFullPathChanged(EventArgs e)
    {
        EventHandler handler = ImageFullPathChanged;
        if (handler != null)
            handler(this, e);
    }
    public event EventHandler ImageFullPathChanged;
