    public class Exchange
    {
       public List<Bank> Banks { get; set; } = new List<Bank>();
    
       public void NegotiateRates()
       {
          while (!CanModifyRates)
          {
             // to the rate stuff in here
          }
       }
    
       public bool CanModifyRates => Banks.All(x => x.AllowRateModification);
    
    }
    ...
    private static void Main()
    {
       var exchange = new Exchange();
       exchange.Banks.Add(new Bank("Royal Bank of Scotland", true));
       exchange.Banks.Add(new Bank("LLoyds", true));
       exchange.Banks.Add(new Bank("HSBC", false));
    
       exchange.NegotiateRates();
    }
