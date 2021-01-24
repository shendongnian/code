    var myDict = new Dictionary<string, string>();
    
    foreach (var prop in jsonResponse.GetType().GetProperties())
    {
    	if (!myDict.ContainsKey(prop.Name))
    		myDict.Add(prop.Name, prop.GetValue(jsonResponse)?.ToString());
    }
