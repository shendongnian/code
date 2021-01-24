    var date = new DateTime(now.Year - 1, now.Month, 1);
    var result = db.Orders
      .Where(o => o.Customer.IsNew && o.State != OrderState.Cancelled) // get all orders where the Customer is a new one.
      .GroupBy(o => o.Customer.Id) // group by customer
      .Select(g => g.OrderBy(o => o.OrderDate).FirstOrDefault()) // get the first order for every customer
      .Where(o => o.OrderDate > date) // restrict to the given date
      .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month) }) // then group by month
      .Select(g => new NewCustomerStatsModel {
        Month = g.Key.Month,
        Year = g.Key.Year,
        Count = g.Count()
      })
      .OrderBy(g => g.Year)
      .ThenBy(g => g.Month)
      .ToList();
            
