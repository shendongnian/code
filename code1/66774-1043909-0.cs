    static void Main(string[] args)
    {
        float a = 5 / float.NegativeInfinity;
        float b = 5 / float.PositiveInfinity;
        float c = 1 / a;
        float d = 1 / b;
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
    }
