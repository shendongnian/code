    class GroceryItem
    {
    	public string name;
    
    	public double price;
    
    	public PurchasedItem Purchased { get; private set; }
    
    	public GroceryItem(string a, double b)
    	{
    		name = a;
    		price = b;
    		Purchased = new PurchasedItem(this);
    	}
    }
    
    class PurchasedItem
    {
    	public int quantity { get; set; }
    	private GroceryItem _groceryItem;
    
    	public PurchasedItem(GroceryItem price)
    	{
    		_groceryItem = price;
    	}
    	public double FindCost()
    	{
    		return _groceryItem.price * this.quantity * 1.10;
    	}
    
    	class FreshItem
    	{
    		public double weight;
    	}
    }
 
