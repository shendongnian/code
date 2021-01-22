    string previous = null;
    foreach(string item in list)
    {
        if (previous != null)
            Console.WriteLine("Looping : {0}", previous);
        previous = item;
    }
    if (previous != null)
        Console.WriteLine("Last one : {0}", previous);
