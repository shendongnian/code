    IQueryable<Whatever> query = context.Table;
    if(condition)
        query = query.Where(x => x.column1);
    if(anotherCondition)
        query = query.Where(x => x.column1);
    //...etc
    var list = query.ToList();
