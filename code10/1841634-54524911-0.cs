    public Class[] FindByFilter(int limit, int? heightId = null, int? ageId = null, int? genderId = null)
    {
        var classes = databaseContext.Set<Class>();
        if (heightId.HasValue)
            classes = classes.Where(c => c.HeightId == heightId.Value);
        if (ageId.HasValue)
            classes = classes.Where(c => c.AgeId == ageId.Value);
        if (heightId.HasValue)
            classes = classes.Where(c => c.GenderId == genderId.Value);    
        return classes.Take(limit).ToArray();
    }
