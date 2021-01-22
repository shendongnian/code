    // The Parser class extracts the data to hardcoded properties.
    // it's 1200 lines - too many to post on StackOverflow
    JpegParser parser = new JpegParser(path);
    if (parser.ParseDocument())
    {
        Console.WriteLine("Parsed {0} {1}", System.IO.Path.GetFileName(path), parser.Title);
        Console.WriteLine("Tags: {0}", parser.KeywordString);
        Console.WriteLine("Description: {0}", parser.Description);
        Console.WriteLine("Title: {0}", parser.Title);
        Console.WriteLine("Rating: {0}", parser.Rating);
    }
