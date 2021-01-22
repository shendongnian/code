    static (bool success, string value) GetValue(string key)
    {
        if (!_dic.TryGetValue(key, out string v)) return (false, null);
        return (true, v); // this is a ValueType literal
    }
    
    static void Main(string[] args)
    {
        var (s, v) = GetValue("foo"); // (s, v) desconstructs the returned tuple
        if (s) Console.WriteLine($"foo: {v}");
    }
