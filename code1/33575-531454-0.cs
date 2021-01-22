    public new void Enqueue(Delegate d)
    {
        base.Enqueue(d);
        OnChanged(EventArgs.Empty);
    }
