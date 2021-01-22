    public interface SalesStrategy
        {
            double CalculatePrice(double basePrice);
        }
    
    public class FixedPriceSale : SalesStrategy
        {
            public double CalculatePrice(double basePrice)
            {
                return basePrice;
            }
        }
    
    public class AmountOffSale : SalesStrategy
        {
            public double SalesAmount { get; set; }
    
            public AmountOffSale(double salesAmount)
            {
                this.SalesAmount = salesAmount;
            }
    
            public double CalculatePrice(double basePrice)
            {
                return basePrice - SalesAmount;
            }
        }
