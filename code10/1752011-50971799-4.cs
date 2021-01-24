    public static IEnumerable<int> DoThings(this int n)
    {
        return DoThings((long) n).Cast<int>();
    }
    public static IEnumerable<long> DoThings(this long n)
    {
        var mList = new List<int> { 2, 3, 4, 5 };
        var result = new List<long>();
        foreach(var m in mList)
            result.Add(n * m);
    
        return result;
    }
