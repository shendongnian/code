    static void Main()
    {
        object foo = null;
        SetMyObject(ref foo);
    
        bool test = foo == null;
    }
    
    public static void SetMyObject(ref object foo)
    {
        foo = new object();
    }
