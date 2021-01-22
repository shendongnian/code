    var resx = ResourcesName.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, false, false);
                
    foreach (DictionaryEntry dictionaryEntry in resx)
    {
        Console.WriteLine("Key: " + dictionaryEntry.Key);
        Console.WriteLine("Val: " + dictionaryEntry.Value);
    }
