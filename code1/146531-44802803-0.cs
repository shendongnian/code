    //Defining Dictionary
    Dictionary<string, List<string>> ListDict = new Dictionary<string, List<string>>();
    
    //Add lists in Dictionary 
    OnClick(string listname)
    {
    ListDict.Add(listname, new List<string>());
    }
    
    //Add values in List  
    ListDict[listname].Add("xyz");
