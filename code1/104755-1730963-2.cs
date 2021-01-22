        var b = new FooBar();
        b.DoWork += b_OnWorkCompleted;
        b.DoWork += c_OnWorkCompleted;
        Console.WriteLine(b.IsAttached(c_OnWorkCompleted));
        Console.WriteLine(b.IsAttached(b_OnWorkCompleted));
        Console.WriteLine(b.IsAttached(FooBar));
