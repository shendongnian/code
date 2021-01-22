    public BaseClass() : base(FindClassName)
    {
    }
    private static string FindClassName(VeryBaseClass @this)
    {
        return @this.GetType().Name;
    }
