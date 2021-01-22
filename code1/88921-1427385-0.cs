    var list = new SortedList<string, string>
    {
        { "X", "29" },
        { "A", "30" },
        { "C", "44" },
    };
    Console.WriteLine(list.Keys[1]); // Prints "C"
    Console.WriteLine(list.Values[1]); // Prints "44"
