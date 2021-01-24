    static void Main(string[] args)
    {
        var lst = new List<string>() { "A", "B", "C" };
        StringBuilder sb = new StringBuilder();
        lst.ForEach(str => sb.Append(str.ToLower()));
        Console.Write("Output: {0}", sb.ToString());
        Console.ReadKey();
    }
