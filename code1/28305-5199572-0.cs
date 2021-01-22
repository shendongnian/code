    from cust in ctx.Customers
    where cust.CustomerID != ""
    group cust.City /*here*/ by cust.Country
    into grp
    select new
    {
            Country = grp.Key,
            Count = grp.Distinct().Count()
    };
