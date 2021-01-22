    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
    {
        Console.SetOut(writer);
        Console.WriteLine("Hello World");
    }
    var result = sb.ToString();
    // The result variable will contain Hello World\r\n
