    // First we need to split up the initial string
    string[] items = initialString.Split("'");
    
    // Then we filter it so that we have a list of OU and non-OU items
    string[] ouItems = items.Where(s=>s.StartsWith("OU=")).ToArray();
    string[] nonOuItems = items.Where(s=>!s.StartsWith("OU=")).ToArray();
    
    List<string> mainList = new List<string>();
    
    // Our main loop
    for (int i = 0; i < ouItems.Length; i++)
    {
        List<string> localList = new List<string>();
        
        // We loop through all the previous items including the current one
        for (int j = 0; j <= i; j++)
        {
            localList.Add(ouItems[i]);
        }
        // Then we add all of the non-OU items
        localList.AddRange(nonOuItems);
    
        // Then we build the string itself
        bool first = true;
        StringBuilder sb = new StringBuilder();
        foreach (string s in localList)
        {
            if (first) first = false;
            else sb.Append (","); // Separating the items with commas
            sb.Append(s);
        }
        mainList.Add(sb.ToString());
    }
    
    // Now we only have to convert it back to an array
    string[] finalArray = mainList.ToArray();
