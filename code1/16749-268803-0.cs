    public virtual void OnEventConsumed(object sender, EventArgs e)
    {
        if (EventConsumed != null)
            EventConsumed(this, e);
    }
