    var lookup = transactionLines
      .ToClusters(line => line.IsDiscount())
      .Where(cluster => 2 <= cluster.Count) //discard the discounts with no articles
      .SelectMany(
        cluster => cluster.Take(cluster.Count - 1),
        (cluster, article) => new { Discount = cluster.Last(), Article = article })
      .ToLookup(
        pair => pair.Discount,
        pair => pair.Article
      ).ToList();
