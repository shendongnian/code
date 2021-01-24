    public static IEnumerable<int> DoThings(this Int16 n)
    {
        return DoThings((Int32) n);
    }
    public static IEnumerable<int> DoThings(this Int32 n)
    {
        var mList = new List<int> { 2, 3, 4, 5 };
        var result = new List<int>();
        foreach(var m in mList)
            result.Add(n * m);
    
        return result;
    }
