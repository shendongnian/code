    public static void Main(string[] args)
    {
        var integers = new List<int>() { 1, 2, -5 };
        Converter<int, string> converter = x =>
        {
            if (x < 0)
                throw new NotSupportedException();
    
            return x.ToString();
        };
    
        // This code would throw
        //var result1 = integers.ConvertAll(converter).ToArray();
        //Console.WriteLine(String.Join(Environment.NewLine, result1));
    
        // This code ignores -5 element
        var result2 = RobustEnumerating(integers, converter).ToArray();
        Console.WriteLine(String.Join(Environment.NewLine, result2));
    }
    
    public static IEnumerable<K> RobustEnumerating<T, K>(IEnumerable<T> input,
        Converter<T, K> converter)
    {
        List<K> results = new List<K>();
        foreach (T item in input)
        {
            try
            {
                results.Add(converter(item));
            }
            catch { continue; }
        }
        return results;
    }
