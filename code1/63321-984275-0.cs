    public static void CallBar<TR>(Foo<TR> foo)
    {
        Func<MethodInfo, bool> match = m => m.Name == "Bar";
        Type fooType = typeof(Foo<>);
        Console.WriteLine("{0}:", fooType);
        MethodInfo[] methods = fooType.GetMethods().Where(match).ToArray();
            
        foreach (MethodInfo mi in methods)
        {
            Console.WriteLine(mi);
        }
        Console.WriteLine();
        fooType = foo.GetType();
        Console.WriteLine("{0}:", fooType);
        MethodInfo[] methods2 = fooType.GetMethods().Where(match).ToArray();
        foreach (MethodInfo mi in methods2)
        {
            Console.WriteLine(mi);
        }
    }
