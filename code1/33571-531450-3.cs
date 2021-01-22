    public override void Enqueue(object obj)
    {
        base.Enqueue(obj);
        OnChanged(EventArgs.Empty);
    }
