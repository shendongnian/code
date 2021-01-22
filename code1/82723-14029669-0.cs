    public static string TestNameMethod(params Func<object, object>[] args)
    {
        var name = (args[0].Method.GetParameters()[0]).Name;
        var val = args[0].Invoke(null);
        var name2 = (args[1].Method.GetParameters()[0]).Name;
        var val2 = args[1].Invoke(null);
        Console.WriteLine("{0} : {1}, {2} : {3}", name, val, name2, val2);
    }
