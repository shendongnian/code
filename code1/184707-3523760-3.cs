    string[] strings = new[] { "1", "2", "abc", "3", "", "123" };
    
    int[] ints = strings.TryConvertAll<string, int>(int.TryParse).ToArray();
    
    foreach (int x in ints)
    {
        Console.WriteLine(x);
    }
