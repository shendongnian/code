    public static decimal ChangePercentage(this IEnumerable<Trade> trades, DateTime startDate, DateTime endDate)
    {
        return trades.ChangePercentage(trade => trade.TradeTime >= startDate 
            && trade.TradeTime <= endDate);
    }
    public static decimal ChangePercentage(this IEnumerable<Trade> trades, Func<Trade, bool> filter)
        {
            var query = from trade in trades
                        where filter(trade)
                        orderby trade.TradeTime descending
                        select trade;
            return (query.First().Value - query.Last().Value) / query.First().Value * 100;
        }
