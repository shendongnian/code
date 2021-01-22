    DateTime now = DateTime.Now;
    DateTime thisMonth = new DateTime(now.Year, now.Month, 1);
    Dictionary<string, decimal> dict;
    using (DemoLinqDataContext db = new DemoLinqDataContext())
    {
        var monthlyTotal = from a in db.Accounts
            where a.Date_Assigned > thisMonth.AddMonths(-6)
            group a by new {a.Date_Assigned.Year, a.Date_Assigned.Month} into g
            select new {Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                        Total = g.Sum(a=>a.Amount_Assigned)};
        dict = monthlyTotal.OrderBy(p => p.Month).ToDictionary(n => n.Month.ToString("MMM"), n => n.Total);
    }
