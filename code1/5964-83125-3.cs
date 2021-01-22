    static void Main(string[] args)
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict[1] = "value1";
        dict[2] = "value2";
        dict[3] = "value3";
        foreach (KeyValuePair<int, string> item in dict)
        {
            Console.WriteLine("Key : {0}, Value: {1}", new object[] { item.Key, item.Value });
        }
        string[] values = new string[dict.Values.Count];
        dict.Values.CopyTo(values, 0);
        foreach (string value in CreateReverseIterator(values))
        {
            Console.WriteLine("Value: {0}", value);
        }
    }
