    public abstract class Money {
    
      public abstract decimal GetCurrencyConversionRate(string isoCurrencySymbol);
    
      ...
    
    }
    
    public class SubMoney : Money {
    
      public override decimal GetCurrencyConversionRate(string isoCurrencySymbol) {
        ...
      }
    
    }
