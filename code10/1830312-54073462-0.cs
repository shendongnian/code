    int i = 0;
    int ammount = 1000;
    int total = db.Customers.Count();
    while (i < total)
    {
        ammount = Math.Min(ammount, total);
        var part = db.Customers.OrderBy(x=>x.Id).Skip(i).Take(ammount).ToList();
        i += ammount;
    }
