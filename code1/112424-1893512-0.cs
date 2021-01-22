    public interface ICurrencyProvider {
       Currency GetCurrency();
    }
    // Implment the default:
    public class DefaultCurrencyProvider : ICurrencyProvider {
       public Currency GetCurrency() {
          return new Currency("AUD");
       }
    }
    
    // And the Payment constructor will look like:
    public Payment(decimal amount, ICurrencyProvider currencyProvider) {
       c = currencyProvider.GetCurrency();
    }
