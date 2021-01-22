    string[] names = Enum.GetNames(typeof(Colors));
    Array values = Enum.GetValues(typeof(Colors));
    for (int i=0;i<names.Length;++i)
    {
        Console.WriteLine("{0} : {1}", names[i], values[i]);
    }
