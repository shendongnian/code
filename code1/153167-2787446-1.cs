    Dictionary<string, HashSet<int>> dict = new Dictionary<string, HashSet<int>>();
    dict.Add("foo", new HashSet<int>() { 15, 12, 16, 18 });
    dict.Add("boo", new HashSet<int>() { 16, 47, 45, 21 });
    var query = dict.Select(entry => entry.Value.Select(value => value.ToString()))
                    .Transpose();
    foreach (var key in dict.Keys)
    {
        Console.Write(String.Format("{0,-5}", key));
    }
    Console.WriteLine();
    foreach (var row in query)
    {
        foreach (var item in row)
        {
            Console.Write(String.Format("{0,-5}", item));
        }
        Console.WriteLine();
    }
    Console.ReadKey();
