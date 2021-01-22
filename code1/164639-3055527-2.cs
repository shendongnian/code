    [DllImport("Foo")]
    public static extern void Foo(Callback c);
    static Callback PrintOutRef; // to prevent garbage collection of the delegate
    public void CallFoo()
    {
        Foo(PrintOutRef = PrintOut);
    }
