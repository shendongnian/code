    foreach (string is in itemsSold)
    {
    foreach (string id in ItemIDs)
    {
        string s = is.Replace(";", "");
        string d = id.Replace(";", "");
        displayformat += s + " - " + d + Environment.NewLine;
    }
    }
    
    Console.WriteLine(displayformat);
