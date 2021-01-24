    if(searchByName) //Some boolean value to indicate you are searching the name
    {
        geocodes = geocodes.Where(s => s.NAME.Contains(searchString));
    }
    if(searchBySite)
    {
        geocodes = geocodes.Where(s => s.CFN_SITE.Contains(searchString));
    }
    if(searchByAddress)
    {
        geocodes = geocodes.Where(s => s.STREET1.Contains(searchString));
    }
    //etc...
