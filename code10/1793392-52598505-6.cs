    static void Main(string[] args)
    {
        ...
        var result = string.IsNullOrEmpty(text) ? "Empty" : CheckDuplicate(text);
        Console.WriteLine(result);
    }
