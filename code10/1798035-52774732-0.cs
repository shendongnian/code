    var query = cr.faultStat;
    // the user selected a min-date-filter?
    if(minDate.HasValue)
    {
        query = query.Where(x => x.Date > minDate.Value);
    }
    // the user selected a max-date-filter?
    if(maxInclusiveDate.HasValue)
    {
        query = query.Where(x => x.Date <= maxInclusiveDate.Value);
    }
    // the user selected an id-filter?
    if(id.HasValue)
    {
        query = query.Where(x => x.Id == id.Value);
    }
    
    var rslt = query
        .Select(x => select new
        {
            t.name,
            t.fname, ...
        });
