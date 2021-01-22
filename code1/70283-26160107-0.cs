<code class='sharp'>
    public static void SomeMethod()
    {
        string s1 = "a";
        string s2 = "b";
        Swap(ref s1, ref s2);
        Console.WriteLine(s1);
        Console.WriteLine(s2);
    }
    
    public static void Swap(ref Object a, ref Object b)
    {
        Object t = b;
        b = a;
        a = t;
    }
