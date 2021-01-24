    .SelectMany(
    	o => o.Details.Select(d => d.Delivery).Take(1).DefaultIfEmpty(),
    	(o, d) => new { Order = o, Delivery = d })
    .OrderByDescending(v => v.Delivery.ProductId)
    .ThenByDescending(v => v.Delivery.Value)
    .ThenByDescending(v => v.Order.CreatedAt)
    .Select(v => v.Order) // restore the original projection
