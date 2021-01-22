    static int x = 0;
    
    public static void Foo()
    {
        try { return; }
        finally { x = 1; }
    }
    
    static void Main() { Foo(); }
