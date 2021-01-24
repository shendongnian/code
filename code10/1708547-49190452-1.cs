    var clientsWithOnlyOneCost100 = clients.Select(c => new
    {
        client = c,
        orders = c.Orders.Where(x => x.Cost > 100)
    })
        .Where(a => a.orders.Count() == 1);
