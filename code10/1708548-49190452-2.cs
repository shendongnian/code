    var clientsWithOnlyOneCost100 = clients.Select(c => new
    {
        client = c,
        orders = c.Orders.Where(o => o.Cost > 100)
    })
        .Where(x => x.orders.Count() == 1);
