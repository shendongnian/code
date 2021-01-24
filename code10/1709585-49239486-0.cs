    public static void main(string[] args)
    {
        string input = @"""MyName""<myname@11.com>";
        string regex = "<[^>]*>";
        Console.WriteLine(Regex.Match(input, regex).Value);
    }
