    public static void CallBar&lt;TR&gt;(Foo&lt;TR&gt; foo)
    {
        Func&lt;MethodInfo, bool&gt; match = m => m.Name == "Bar";
        Type fooType = typeof(Foo&lt;&gt;);
        Console.WriteLine("{0}:", fooType);
        MethodInfo[] methods = fooType.GetMethods().Where(match).ToArray();
            
        foreach (MethodInfo mi in methods)
        {
            Console.WriteLine(mi);
        }
        Console.WriteLine();
        fooType = foo.GetType();
        Console.WriteLine("{0}:", fooType);
        methods = fooType.GetMethods().Where(match).ToArray();
        foreach (MethodInfo mi in methods)
        {
            Console.WriteLine(mi);
        }
    }
