    var IQueryable<bla> query = myDataContext.BlahTable;  // I think you can also use IEnumerable.
    
    if(/* something */)
    {
        query = query.Where(b => b.Field1 > 0);
    }
    if(/* something else */)
    {
        query = query.OrderBy(b => b.Field2);
    }
