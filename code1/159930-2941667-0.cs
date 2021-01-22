    public class Order
    {
        public string Vender { get; set; }
        public decimal Amount { get; set; }
    }
    public class AnotherOrder
    {
        public string Vender { get; set; }
        public decimal Amount { get; set; }
        public static explicit operator AnotherOrder(Order o)
        {
            //this method can be put in Order or AnotherOrder only
        }
    }
	
