    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        var result = Add_Multiply(a, b);
        Console.WriteLine(result.Item1);
        Console.WriteLine(result.Item2);
    }
     
    private static Tuple<int, int> Add_Multiply(int a, int b)
    {
        var tuple = new Tuple<int, int>(a + b, a * b);
        return tuple;
    }
