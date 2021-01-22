    public class Customer
    {
       public Int32 Id { get; private set; }
       public String Name { get; private set; }
       public String Address { get; private set; }
       public String City { get; private set; }
    
       public IList<Order> Orders { get { return this.orders; } }
       private readonly IList<Orders> orders = new List<Orders>();
    }
    
    Class Order
    {
       public Int32 Id { get; private set; }
       public String SalesPersonName { get; private set; }
       public Decimal SubTotal { get; private set; }
    
       public Customer Customer { get; private set; }
    }
