    string lastItem = list.Last();
    foreach (string item in list) {
        if (!object.ReferenceEquals(item, lastItem))
            Console.WriteLine("Looping: " + item);
        else        Console.WriteLine("Lastone: " + item);
    }
