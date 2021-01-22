    private List<string> managedLocationIDList = new List<string>();
    string managedLocationIDs = ";1321;1235;;" // user input, should be semicolon seperated list of values
    
    managedLocationIDList.AddRange(managedLocationIDs.Split(new char[] { ';' }));
    List<string> checkLocationIDs = new List<string>();
    
    // Remove any duplicate ID's and cleanup the string holding the list if ID's
    Functions helper = new Functions();
    checkLocationIDs = helper.ParseList(managedLocationIDList);
    
    ...
    public List<string> ParseList(List<string> checkList)
    {
        List<string> verifiedList = new List<string>();
    
        foreach (string listItem in checkList)
    	if (!verifiedList.Contains(listItem.Trim()) && listItem != string.Empty)
    	    verifiedList.Add(listItem.Trim());
    
        verifiedList.Sort();
        return verifiedList;
    }        
