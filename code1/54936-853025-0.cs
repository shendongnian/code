    private void Form1_Load(object sender, EventArgs e)
            {
                //signature of our function
                Func<IEnumerable<Trade>, DateTime, DateTime, decimal> changePercentage = null;
    
                //function implemented using lambda expression syntax
                changePercentage += (trades, startDate, endDate) => 
                {
                    var query = from trade in trades
                                where trade.TradeTime >= startDate
                                where trade.TradeTime <= endDate
                                orderby trade.TradeTime
                                descending
                                select trade;
                    return (query.First().Value - query.Last().Value) / query.First().Value * 100;
                };
            }
