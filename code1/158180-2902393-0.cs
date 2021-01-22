    using ( var session = new MongoSession<Order>( DbName ) )
    {
        var orders = session.Queryable
                    .Where( o => o.OrderItems.Any( oi => oi.Quantity > 10 ) )
                    .ToList();
    }
