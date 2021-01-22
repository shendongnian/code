    public event EventHandler<FileManagerEventArgs> Loaded;
    public void Load()
    {
        ...
        OnLoaded(new FileManagerEventArgs("no errors"));
    }
    protected virtual void OnLoaded(FileManagerEventArgs e)
    {
        EventHandler<FileManagerEventArgs> handler = this.Loaded;
        if (handler != null)
        {
            handler(this, e);
        }
    }
