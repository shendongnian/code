    public static decimal ChangePercentage(this IEnumerable<Trade> trades, Func<Trade,bool> pred)
            {
                var query = from trade in trades
                            where pred(trade);
                            orderby trade.TradeTime descending
                            select trade;
                return (query.First().Value - query.Last().Value) / query.First().Value * 100;
            }
    
        someTrades.ChangePercentage(x => x.TradeDate >= startDate && x.TradeTime <= endDate);
