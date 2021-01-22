    //use the filter from above
    
    SearchResultCollection src = ds.FindAll();  
    
    foreach(SearchResult sr in src)
    
    {
    
         DateTime lockoutTime = DateTime.FromFileTime((long)sr.Properties["lockoutTime][0]);
    
         Response.Output.Write("Locked Out on: {0}", lockoutTime.ToString());
    
    }
