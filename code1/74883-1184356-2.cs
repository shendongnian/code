    public static DynamicFunc MakeDynamicFunc(object target, MethodInfo method)
    {
        return par => method.Invoke(target, par);
    }
    public static void Foo(string s, int n)    
    {
        Console.WriteLine(s);
        Console.WriteLine(n);
    }
