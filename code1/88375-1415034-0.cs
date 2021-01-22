    IQueryable<SomeType> query = db.MyTable;
    if(minValue != null) // a Nullable<double>
    {
        var actualMin = minValue.Value;
        query = query.Where(d => (double) d.Price >= actualMin);
    }
    if(maxValue != null) // a Nullable<double>
    {
        var actualMax = maxValue.Value;
        query = query.Where(d => (double) d.Price <= actualMax);
    }
    // keep working with "query", for example, query.ToList();
