    public class Pricing
    {
        public int ID { get; set; }
        public int Price { get; set; }
    }
    public class CustomerModelBinder
    {
        public Customer Cust{get; set}
        public Order order{get;set}
        public Pricing pricing{get; set}
        public CustomerModelBinder(int custBasePrice)
        {
            Cust.baseprice = custBasePrice;
            pricing.Price = Cust.baseprice * 10;
        }
    }
