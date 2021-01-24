    var final = new List<T>();
    // Add all the lists only if they match
    UnionIfMatches(gardenvlist);
    UnionIfMatches(oceanvlist);
    UnionIfMatches(cityvlist);
    if (final.Count() > 0)
        return new ObjectResult(final);
    return NotFound();
    // ---- Local Functions ---- //
    
    // Adds the list to final if it matches
    void UnionIfMatches(List<T> list)
    {
        if (ListMatches(list))
            final.Union(list);
    }
    
    // Checks if the list matches
    bool ListMatches(List<T list> => list.Select(x => xmethod.RateGroupID.Count() == days);
