    var lookup = transactionLines
      .ToClusters(line => line.IsDiscount())
      .Where(cluster => 2 <= cluster.Count) //discard the discounts with no articles
      .ToLookup(
        cluster => cluster.Last(),
        cluster => cluster.TakeUntil(line => line.IsDiscount()).ToList()
      ).ToList();
