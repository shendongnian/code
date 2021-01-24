    var inputLines = new Subject<string>();
    inputLines.Subscribe(info =>
    {
        if (info == "hello")
            Console.Out.WriteLine("world");
    });
    while (true)
    {
        var line = Console.In.ReadLine();
        inputLines.OnNext(line);
    }
