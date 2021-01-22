    class Stock {
       string symbol;
       List<decimal> hourlyPrice; // provides a list of 24 decimals
    }
    // get hourly prices from yesterday and today
    List<Stock> stockMondays = Stocks.GetStock("GOOGL,IBM,AAPL", DateTime.Now.AddDay(-1));
    List<Stock> stockTuesdays = Stocks.GetStock("GOOGL,IBM,AAPL", DateTime.Now);
    try {
        foreach(Stock sMonday in stockMondays) {
            Stock sTuesday = stockTuesday[stockMondays.IndexOf(sMonday)];
            
            foreach(decimal mondayPrice in sMonday.prices) {
                decimal tuesdayPrice = sTuesday.prices[sMonday.prices.IndexOf(mondayPrice)];
                // do something now
            }
        }
    } catch (Exception ex) { // some reason why list counts aren't matching? }
