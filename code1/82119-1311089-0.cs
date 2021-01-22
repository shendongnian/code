    var items =
       customers
       .SelectMany(c => c.Orders.SelectMany(
          o => o.Items.Select(i => new { item = i, customer = c })
       ))
       .GroupBy(o => o.item.ItemCode)
       .Select(g => new {
          item = g.First().item,
          customers = g.Select(o => o.customer).Distinct()
       });
