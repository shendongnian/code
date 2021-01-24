    var query = context.Orders
        .GroupBy(o => new { o.CustomerId, o.EmployeeId })
        .Select(g => new
            {
              g.Key.CustomerId,
              g.Key.EmployeeId,
              Sum = g.Sum(o => o.Amount),
              Min = g.Min(o => o.Amount),
              Max = g.Max(o => o.Amount),
              Avg = g.Average(o => Amount)
            });
