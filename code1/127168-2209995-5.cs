    var names = Enum.GetNames(typeof(Colors));
    var values = Enum.GetValues(typeof(Colors));
    for (int i=0;i<names.Length;++i)
    {
        Console.WriteLine("{0} : {1}", names[i], (int)values.GetValue(i));
    }
