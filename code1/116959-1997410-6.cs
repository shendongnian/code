        foreach (string theKey in mainDict.Keys)
        {
            if(mainDict[theKey] is Dictionary<string, object>)
            {
                Console.WriteLine("type of aSubDict");
            } else if (mainDict[theKey] is string)
            {
                Console.WriteLine("type string");
            }
        }
