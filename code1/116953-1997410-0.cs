        Type testType = aSubDict.GetType();
        foreach (string theKey in mainDict.Keys)
        {
            if ((mainDict[theKey]).GetType() == testType)
            {
                Console.WriteLine("Match found");
            }
        }
