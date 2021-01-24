    ConcurrentDictionary<int, String> cd = new ConcurrentDictionary<int, string>();
    string value1;
    if (cd.TryRemove(1, out value1))
    {
        Console.WriteLine($"We have just removed {value1}");
    }
    else 
    {
        Console.WriteLine("cd.TryRemove() did not removed the key of 1");    
    }
