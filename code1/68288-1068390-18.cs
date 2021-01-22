    string previous = null;
    bool isFirst = true;
    foreach (var item in list)
    {
        if (!isFirst)
        {
            Console.WriteLine("Looping: " + previous);
        }
        previous = item;
        isFirst = false;
    }
    if (!isFirst)
    {
        Console.WriteLine("Last one: " + previous);
    }
