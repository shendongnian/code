    public class Order
    {
        // constructors and properties
        public decimal CalculateTotal()
        {
            return (from li in this.LineItems
                    select li.CalculateTotal()).Sum();
        }
    }
