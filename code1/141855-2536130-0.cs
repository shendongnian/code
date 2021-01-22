    var query1 = linq.Customers
    .Where(c => c.ContactName.StartsWith("a"))
    .SelectMany(cus=>cus.Orders)
    .Select(ord => ord.CustomerID);
    
    if(SortAscending)
       query1 = query1.OrderBy(ord => ord.OrderDate);
    else
       query1 = query1.OrderByDescending(ord => ord.OrderDate);
