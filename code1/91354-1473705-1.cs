    IEnumerable myCollection = GetCollection();
    if(myCollection.Any())
    {
        foreach(var item in myCollection)
        {    
            //Do something
        }
    }
    else
    {
       // Do something else
    }
