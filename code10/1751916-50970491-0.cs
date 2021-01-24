    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BasePrice { get; set; }
    }
    public class Pricing
    {
        public int ID { get; set; }
        public int Price => Customer.BasePrice * 10;
        public Customer Customer { get; set; }
    }
