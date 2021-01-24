    var Orders = orderSqlContext.OrderDetails
        .GroupBy(x => new
        {
            x.OrderNumber,
            x.OrderTotal
        })
        .Select(grp => new
        {
            grp.Key.OrderNumber,
            grp.Key.OrderTotal
        }).ToList();
