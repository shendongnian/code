    int size = _farmAnimals.Count;
    for(int i = 0; i < size; i++)
    {
        var s = _farmAnimals[0].Species();
        Console.WriteLine(s);
        _farmAnimals.RemoveAt(0);
    }
