    public class Order
    {
        //other members
        public EntitySet<OrderItem> OrderItems { get; }
    }
    
    public class OrderItem
    {
    	//other members
    	public Order Order { get; }
    }
