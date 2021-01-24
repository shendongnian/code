    namespace Checkout
    {
        public class Item : IEntity
        {
            public int ItemId {get; private set;}
    
            public string Description {get; private set;}
    
            public decimal Price {get; private set;}
        }
    
        public class PurchaseOrder : IAggregateRoot
        {
            public int PurchaseOrderId {get; private set;}
    
            public IList<Item> Items {get; private set;}
    
            public decimal TotalCost => this.Items.Sum(i => i.Price);
    
            public void RemoveItem(int itemId)
            {
                // Remove item by id
            }
        }
    }
