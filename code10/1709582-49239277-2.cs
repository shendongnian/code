    public static void Main(string[] args)
    {
        string input = "<myname@11.com>";
        Regex rx = new Regex(@"<(.*?)>");
        Console.WriteLine(rx.Match(input).Groups[1].Value);
    }
