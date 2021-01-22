    public class PurchaseCounter(
    {
        public Guid Product {get; set; } 
        public int MaxOrders {get; set; } 
        public int int CurrentOrders {get; set; } 
     }
    public static bool Purchase(Product product, Client client)
    {
        PurchaseCounter counter = purchaseCounterDictionary[product.ProductGuid];
        lock(counter)
        {
            if( counter.CurrentOrders < counter.MaxOrders )
            {
                 //do logic to place order
                 counter.CurrentOrders++;
                 return true;  
            } 
            else
            {
                 return false;
            }
        }
     }
  }
