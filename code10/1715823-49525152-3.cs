    var lookup = transactionLines
      .ToClusters(line => line.IsDiscount())
      .Where(cluster => 2 <= cluster.Count) //discard the discounts with no articles
      .ToLookup(
        cluster => cluster.Last(),
        cluster => cluster.Take(cluster.Count - 1).ToList()
      ).ToList();
