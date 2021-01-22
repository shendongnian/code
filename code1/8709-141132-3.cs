    // When you use foreach to enumerate dictionary elements,
    // the elements are retrieved as KeyValuePair objects.
    Console.WriteLine();
    foreach( KeyValuePair<string, string> kvp in openWith )
    {
        Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
    }
    // To get the values alone, use the Values property.
    Dictionary<string, string>.ValueCollection valueColl =
        openWith.Values;
    // The elements of the ValueCollection are strongly typed
    // with the type that was specified for dictionary values.
    Console.WriteLine();
    foreach( string s in valueColl )
    {
        Console.WriteLine($"Value = {s}");
    }
    // To get the keys alone, use the Keys property.
    Dictionary<string, string>.KeyCollection keyColl =
        openWith.Keys;
    // The elements of the KeyCollection are strongly typed
    // with the type that was specified for dictionary keys.
    Console.WriteLine();
    foreach( string s in keyColl )
    {
        Console.WriteLine($"Key = {s}");
    }
