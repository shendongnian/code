    public class Customer
    {
      public List<Order> Orders {get;set;}
    }
      //now to use it
    Customer c = new Customer;
    Order o = c.Orders.First(); //oops, null ref exception;
