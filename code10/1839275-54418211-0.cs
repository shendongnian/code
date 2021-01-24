    if(items.Any(x => x.Name.Any(char.IsDigit)))
    {
        // descending  
        items = items.OrderByDescending(x => x.Name)).ToList()
    }
    else
    {
        // ascending
        items = items.OrderBy(x => x.Name)).ToList()
    }
