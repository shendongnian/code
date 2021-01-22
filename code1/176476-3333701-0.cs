    var splitArray = Regex.Split(input, @"(?<=( |^)[A-Z][a-zA-Z]+):|( )(?=[A-Z][a-zA-Z]+:)")
                                .Where(a => a.Trim() != "").ToArray();
    
    Dictionary<string, string> resultDict = new Dictionary<string, string>();
    for(int i = 0; i < splitArray.Count(); i+=2)
    {
        resultDict.Add(splitArray[i], splitArray[i+1]);
    }
