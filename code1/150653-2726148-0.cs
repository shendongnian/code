    public class Order
    {
        public Customer Customer {get;set;}
        // Other order properties
    }
    
    public class Customer
    {
        public List<Order> Orders {get;set;}
        // Other Customer properties
    }
