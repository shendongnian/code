    var values = Enum.GetValues(typeof(Test));
    foreach (var val in values)
    {
        Console.WriteLine(val.GetHashCode());
        Console.WriteLine(((int)val));
        Console.WriteLine(val);
    }
