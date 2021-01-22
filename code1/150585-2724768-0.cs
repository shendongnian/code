    private int someValue;
    public int SomeValue
    {
        get
        {
             return someValue;
        }
        set
        {
             if(ReadOnly)
                  throw new InvalidOperationException("Object is readonly");
             someValue= value;
        }
