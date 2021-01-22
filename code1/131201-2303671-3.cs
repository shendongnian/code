    public Settings Clone()
    {
        Settings clone = CreateCloneInstance();
        CloneTo(clone);
        return clone;
    }
    protected virtual Settings CreateCloneInstance()
    {
        return new Settings();
    }
    public virtual void CloneTo(Settings clone)
    {
        clone.RootFolder = RootFolder;
        ... + any other properties you might have
    }
