    public EventHandler PlaceHolderChanged;
    string placeholder;
    public string PlaceHolder
    {
        get { return placeholder; }
        set
        {
            if (placeholder != value)
            {
                placeholder = value;
                OnPlaceHolderChanged(EventArgs.Empty);
            }
        }
    }
    protected virtual void OnPlaceHolderChanged(EventArgs e)
    {
        PlaceHolderChanged?.Invoke(this, e);
    }
