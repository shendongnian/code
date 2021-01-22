    static bool S1(bool a, bool b)
    {
        return a || b;
    }
    
    static bool S2(bool a, bool b)
    {
        return (a && !b) || b;
    }
    
    static void Main(string[] args)
    {
        bool[] tf = { true, false };
        bool bSame = true;
    
        foreach(bool a in tf)
            foreach(bool b in tf)
            {
                bSame = bSame && (S1(a, b) == S2(a, b));
            }
    
        Console.WriteLine("S1 {0} S2", bSame ? "==" : "!=");
    }
