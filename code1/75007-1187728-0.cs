    public override void Close()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
