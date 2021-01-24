    public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
        }
    	
    	public class CartItem
    	{
    		public Book Book { get; set;}
    		public int Quantity { get; set;}
    	}
    	
    	public class Order 
    	{
    		public List<CartItem> CartItems { get; set;}
    		public int OrderNumber { get; set;}
    		public decimal OrderTotal { get; set;}
    	}
