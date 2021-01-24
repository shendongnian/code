    var totalTickets = _db.Shops.Where(s => s.ShopWorkers.Any(sw => sw.IdUser == admin.Value))
        .SelectMany(s => s.Tickets.Where(t => t.SellDate.HasValue && t.SellDate.Value.Year == tmpYear.Year))
        .Select(t => new {Month = t.SellDate.Value.Month, t.Points})
        .GroupBy(x => x.Month)
        .Select(x => new {Month = x.Key, TotalPoints = x.Sum(g => g.Points)).ToList();
