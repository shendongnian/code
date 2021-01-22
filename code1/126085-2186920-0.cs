    static void Main(string[] args)
    {
        var data = new List<int> { 1, 2, 3, 4, 5 }.AsQueryable().AppendData();
        Console.WriteLine("Before execute");
        Console.Write("{ ");
        foreach (var x in data)
           Console.Write("{0}, ", x);
        Console.WriteLine( "}");
            
        Console.WriteLine("After execute");
        Console.Read();
    }
        
    // Append extra data. From this point on everything is in memory
    // This should be generic, i.e. AppendData<T>, but I an easy way to "append"
    static IEnumerable<int> AppendData(this IEnumerable<int> data)
    {
        Console.WriteLine("Adding");
        foreach (var x in data)            
            yield return x * 2;
    }
