    public sealed override void Update()
    {
        UpdateCore();
        base.Update();
    }
    
    public abstract /* or virtual */ void UpdateCore()
    {
        // Class-specific stuff
    }
