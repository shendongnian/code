    var query = 
        from order in _context.Orders
        select new OrderListViewModel
        {
            Id = order.Id,
            LineItems = order.LineItems.Select(lineItem => lineItem.FriendlyId).ToArray(),
            Products = order.LineItems.Select(lineItem => lineItem.Product.Name).ToArray(),
        };
