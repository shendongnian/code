    public Constructor(string x) : base(Foo(x))
    {
        // stuff
    }
    private static string Foo(string y)
    {
        return y + "Foo!";
    }
