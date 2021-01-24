    var orders = dbcontext.Orders.Where(o => /* some filter logic */);
    var orderIds = orders.Select(o => o.OrderId).ToList();
 
    // get status for latest change - this should query OrderStatus only
    var statusNameMap = dbContext.OrderStatus
	   .Where(os => orderIds.Contains(Id))
       .GroupBy(os => os.OrderId)
       .Select(grp => grp.OrderByDescending(grp => grp.CreatedDate).First())
       .ToDictionary(os => os.OrderId, os => os.StatusId);
	   
    // aggregate the results
    // the orders might fetch only the needed columns to have less data on the wire
	var result = orders.
		.ToList()
		.Select(o => new { o.Name, statusNameMap[o.OrderId] });
