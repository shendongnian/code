    delegate void RefTest(out bool test);
    static void Main(string[] args)
    {
        var p1 = Expression.Parameter(typeof(bool).MakeByRefType(), "test");
        var func = Expression.Lambda<RefTest>(Expression.Constant(null), p1);
    }
