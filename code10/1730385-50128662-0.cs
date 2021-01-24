    Dictionary<int, string> resultList = new Dictionary<int, string>();
    
    foreach (var item in ID)
    {
       resultList.Add(item,string.Empty);
       try
       {
             // Your Call Here
    
             // Add Result to resultList here
    
           var apiCallResult = apiCall(item);
           resultList[item] = apiCallResult;
       }
       catch
       {
       }
    }
