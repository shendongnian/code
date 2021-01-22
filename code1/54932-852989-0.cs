    public static decimal ChangePercentage(this IEnumerable<Trade> trades)
    {
      var query = trades.OrderByDescending(t => t.TradeTime);
      if (query.Any())
        return (query.First().Value - query.Last().Value) / query.First().Value * 100;
      else
        return 0;
    }
