    namespace Sales
    {
        public class PurchaseOrder : IAggregateRoot
        {
            public int PurchaseOrderId {get; private set;}
        
            public IList<int> Items {get; private set;} //Item ids
        
            public void RemoveItem(int itemIdToRemove)
            {
                // Remove by id
            }
        
            public void AddItem(int itemId) // Received from UI for example
            {
                // Add id to set
            }
        }
    }
