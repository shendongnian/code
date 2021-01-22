    string path = "INSERT PATH HERE";
        
    var assembly = Assembly.LoadFile(path);
    foreach (var type in assembly.GetTypes())
    {
        Debug.WriteLine(type.Name);
        // do check for type here, depending on how you wish to query
    }
