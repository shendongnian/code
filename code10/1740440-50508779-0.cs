    using (var writer = new StringWriter())
    {
        Console.SetOut(writer);
    
        Console.WriteLine("Hello");
        Console.WriteLine("World");
        var writtenText = writer.ToString();
    }
