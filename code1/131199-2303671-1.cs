    public Settings Clone()
    {
        Settings clone = new Settings();
        CloneTo(clone);
        return clone;
    }
    public virtual void CloneTo(Settings clone)
    {
        clone.RootFolder = RootFolder;
        ... + any other properties you might have
    }
