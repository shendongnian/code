    // You may want to tweak the GetMethods for private, static, etc...
    foreach (var method in o.GetType().GetMethods(BindingFlags.Public))
    {
        var del = Delegate.CreateDelegate(gs.GetType(), method, false);
        if (del != null)
        {
            Console.WriteLine("o has a method that matches the delegate type");
        }
    }
