    public event EventHandler Drop;
    
    protected virtual void OnDrop(EventArgs e)
    {
        if (Drop != null)
        {
            Drop(this, e);
        }
    }
