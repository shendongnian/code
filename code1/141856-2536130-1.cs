    var query1 = linq.Customers
    .Where(c => c.ContactName.StartsWith("a"))
    .SelectMany(cus=>cus.Orders)
    
    if(SortAscending)
       query1 = query1.OrderBy(ord => ord.OrderDate);
    else
       query1 = query1.OrderByDescending(ord => ord.OrderDate);
    var query2 = query1.Select(ord => ord.CustomerID);
