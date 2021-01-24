    namespace warehousing
    {
        public class Warehouse : IAggregateRoot
        {
            // Id, name, etc
        
            public IDictionary<int, int> ItemStock {get; private set;} // First int is item Id, second int is stock
    
            public bool IsInStock(int itemId)
            {
                // Check dictionary to see if stock is greater than zero
            }
        }
    }
