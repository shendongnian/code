    private static volatile int backingField;
    public static int Field
    {
        get { return backingField; }
        set { backingField = value; }
    } 
