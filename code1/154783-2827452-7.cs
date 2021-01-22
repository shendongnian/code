    public static void Run()
    {
        var a = 3; // a is int
        var i = a.IdentityFunc(); // i is Func<int, int>;
        var test = i.Compose(n => n)(a) // test is expected to be int
    }
