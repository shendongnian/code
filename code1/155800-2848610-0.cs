    public abstract class Money
    {
        public CurrencyConversionRate
        {
            get
            {
                return GetCurrencyConversionRate(_regionInfo.ISOCurrencySymbol);
            }
        }
    
        public abstract decimal GetCurrencyConversionRate(string isoCurrencySymbol);
    
        public Money ConvertTo(string cultureName)
        {          
            // convert to base USD first by dividing current amount by it's exchange rate.
            Money someMoney = this;
            decimal conversionRate = this.CurrencyConversionRate;
            decimal convertedUSDAmount = Money.Divide(someMoney, conversionRate).Amount;
    
            // now convert to new currency
            CultureInfo cultureInfo = new CultureInfo(cultureName);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
            conversionRate = GetCurrencyConversionRate(regionInfo.ISOCurrencySymbol);
            decimal convertedAmount = convertedUSDAmount * conversionRate;
            Money convertedMoney = new Money(convertedAmount, cultureName);
            return convertedMoney;
        }
    }
    public class SubMoney : Money
    {
        public SubMoney(decimal amount, string cultureName) : base(amount, cultureName) {}
    
        public override decimal GetCurrencyConversionRate(string isoCurrencySymbol)
        {
            // This would get the conversion rate from some web or database source
            decimal result = new Decimal(2);
            return result;
        }
    }
