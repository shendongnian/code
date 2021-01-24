    private static int _k = 10;
    public static int k
    {
        get { Console.WriteLine($"evaluating k ({_k})"); return _k; }
        set { Console.WriteLine($"{value} assigned to k"); _k = value; }
    }
    private static int _c = 30;
    public static int c
    {
        get { Console.WriteLine($"evaluating c ({_c})"); return _c; }
        set { Console.WriteLine($"{value} assigned to c"); _c = value; }
    }
    public static void Test()
    {
        k += c += k += c;
    }
