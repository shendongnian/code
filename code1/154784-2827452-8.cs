    public static void Run()
    {
        var a = 3; // a is int
        var i = a.IdentityFunc(); // i is Func<int, int>;
        var c = i.Compose(n => n) // c is Func<T, int> - T cannot be resolved without knowledge of n
        var test = c(a); // ideally have type inference infer c (Func<T, int>) as Func<int, int>
    }
