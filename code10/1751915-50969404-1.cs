    public class Pricing
    {
        public int ID { get; set; }
        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value * 10;
            }
         }
    }
    public class CustomerModelBinder
    {
        public Customer Cust{get; set}
        public Order order{get;set}
        public Pricing pricing{get; set}
        public CustomerModelBinder(int custBasePrice)
        {
            Cust.baseprice = custBasePrice;
            pricing.Price = Cust.baseprice;
        }
    }
