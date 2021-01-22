    public sealed class CustomerOrder
    {
        public decimal Price;
        public decimal Quantity;
    }
    public static class CustomerOrderExtensions
    {
        public static decimal GetTotalCash(this CustomerOrder data)
        {
            return data.Price*data.Quantity;
        }
    }
