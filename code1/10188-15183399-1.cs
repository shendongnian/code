    public class StatSummary{
          public Statistic<double> NetProfit { get; set; }
          public Statistic<int> NumberOfTrades { get; set; }
          public StatSummary(double totalNetProfit, int numberOfTrades)
          {
              this.TotalNetProfit = new Statistic<double>("Total Net Profit", totalNetProfit);
              this.NumberOfTrades = new Statistic<int>("Number of Trades", numberOfTrades);
          }
    }
    StatSummary summary = new StatSummary(750.50, 30);
    Console.WriteLine("Name: " + summary.NetProfit.Name + "    Value: " + summary.NetProfit.Value);
    Console.WriteLine("Name: " + summary.NumberOfTrades.Value + "    Value: " + summary.NumberOfTrades.Value);
    
