    private static readonly string[] sequence = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15".Split(',');
    
    static void Main(string[] args)
    {
        var every4thElement = sequence
          .Where((p, index) => index % 4 == 0);
        
        foreach (string p in every4thElement)
        {
            Console.WriteLine("{0}", p);
        }
        Console.ReadKey();
    }
