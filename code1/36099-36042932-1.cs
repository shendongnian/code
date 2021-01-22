    var splitter = new StringSplitter(2);
    splitter.Split("Hello World", ' ');
    if (splitter.Results[0] == "Hello" && splitter.Results[1] == "World")
    {
        Console.WriteLine("It works!");
    }
