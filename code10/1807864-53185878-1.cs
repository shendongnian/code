    public class StockService
    {
    	private readonly object _availableQtyLock = new object();
    	
    	public bool UpdateStock(int productId, int purchaseQty)
    	{
    		using (var db = new MyEntities())
    		{ 
    			lock (_availableQtyLock)
    			{
                    var stock = db.Products.Find(productId);
    				if (stock.AvailableQty >= purchaseQty) // Condition to check the availablity
    				{
    					stock.AvailableQty = stock.AvailableQty - purchaseQty;
    					db.SaveChanges();
    					return true;
    				}
    				return false;
    			}
    		}
    	}
    }
