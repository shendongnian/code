    [Flags]
    public enum Time
    {
        None = 0
        Current = 1,
        Past = 2,
        Future = 4
    }
    myProp = Time.Past | Time.Future;
    if (myProp.HasFlag(Time.Past))
    {
        // Past is set...
    }
