    // Prices: Key - distance; Value - price
    private static Dictionary<decimal, decimal> defaultPrices = 
      new Dictionary<decimal, decimal>() {
        { 100m, 1.00m},
        {  50m, 1.25m},
        {  10m, 1.50m},
        {   0m, 2.00m},
    };
    private static decimal Price(decimal distance, 
      IDictionary<decimal, decimal> policy = null) {
      // if no price policy provided, use default one
      if (null == policy)
        policy = defaultPrices;
      decimal result = 0.00m;
      while (distance > policy.Keys.Min()) {
        var pair = policy
          .Where(item => distance > item.Key)
          .OrderByDescending(item => item.Key)
          .First();
        result += (distance - pair.Key) * pair.Value;
        distance = pair.Key;
      }
      return result;
    }
