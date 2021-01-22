    public class CustomerProxy:Customer,IEntityWithChangeTracker
    {
    private ICollection<Order> orders;
       public override ICollection<Order> Orders
       {
            if(orders == null)
           {
               orders = new EntityCollection<Order>();
               orders.Load();
           }
           return orders;
       }
    }
