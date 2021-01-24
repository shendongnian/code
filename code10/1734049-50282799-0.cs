    using (var sr = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
    {
        var input = sr.ReadToEnd();
        var tokens = input.Replace(Environment.NewLine, " ").Split(" ");
        foreach (var t in tokens)
        {
            Console.WriteLine($"Token: \"{t}\"");
        }
        Console.Read();
    }
