    var queryableData = companies.AsQueryable();
    var pe = Expression.Parameter(typeof(string), "company");
    var orderByCall = Expression.Call(typeof(Queryable),
        "OrderBy",
        new []{ queryableData.ElementType,
                queryableData.ElementType }, // <-- fix #1 select correct overload
        queryableData.Expression,            // <-- fix #2 pass first argument
        Expression.Lambda<Func<string, string>>(pe, pe)
      );
    
