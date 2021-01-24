    public async Task MyCallingMethod()
    {
        var users = await GetUsersByField(...);
    
        foreach(var w in users ) 
        {
           ...
        }
    }
