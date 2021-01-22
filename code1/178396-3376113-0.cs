public abstract class SalesStrategy
{
    public abstract double GetPrice(double saleAmount, double basePrice = 0d);
}
public class AmountOffSale : SalesStrategy
{
    public override double GetPrice(double salesAmount, double basePrice = 0d)
    {
        return basePrice - salesAmount;
    }
}
public class FixedPriceSale : SalesStrategy
{
    public override double GetPrice(double salesAmount, double basePrice = 0d)
    {
        return salesAmount;
    }
}
