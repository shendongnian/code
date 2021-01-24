    var data = "15:00";
    if (TimeSpan.TryParse(data, out var time))
    {
        Console.WriteLine("Time: {0}", time);
    }
    else if (DateTime.TryParse(data, out var datetime))
    {
        Console.WriteLine("DateTime: {0}", datetime);
    }
    else
    {
        Console.WriteLine("I don't know how to parse {0}", data);
    }
