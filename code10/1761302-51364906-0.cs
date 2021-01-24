    static void NullCoalescing(List<int> a)
    {
        a = a ?? new List<int>();
        Console.WriteLine(a);
    }
    static void IfStatement(List<int> a)
    {
        if(a == null) a = new List<int>();
        Console.WriteLine(a);
    }
