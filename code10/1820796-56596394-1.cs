    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack;
    using ServiceStack.Text;
	public class AlphaVantageData
 	{
         public DateTime Timestamp { get; set; }
         public decimal Open { get; set; }
         public decimal High { get; set; }
         public decimal Low { get; set; }
         public decimal Close { get; set; }
         public decimal Volume { get; set; }
	}
     // retrieve monthly prices for Microsoft
     var symbol = "MSFT";
     var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey=demo&datatype=csv"
                .GetStringFromUrl().FromCsv<List<AlphaVantageData>>();
     monthlyPrices.PrintDump();
     // some simple stats
     var maxPrice = monthlyPrices.Max(u => u.Close);
     var minPrice = monthlyPrices.Min(u => u.Close);
