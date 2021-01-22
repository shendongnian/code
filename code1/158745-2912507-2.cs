    string stringToCheck = "text1";
    string[] stringArray = { "text1", "testtest", "test1test2", "test2text1" };
    foreach (string x in stringArray)
    {
        if (stringToCheck.Contains(x))
        {
            // Process...
        }
    }
