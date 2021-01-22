    var linq = new NorthwindDataContext();
    var query = linq.Customers
        .Where(c => c.ContactName.StartsWith("a"))
        .SelectMany(cus=>cus.Orders);
    IOrderedEnumerable<Order> query2;
    if (useAscending) {
        query2 = query.OrderBy(ord => ord.OrderDate);
    } else {
        query2 = query.OrderByDescending(ord => ord.OrderDate);
    }
    var query3 = query2.Select(ord => ord.CustomerID);
