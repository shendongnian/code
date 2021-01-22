        public class Order
        {
            public Guid ID { get; set; }
            private List<Item> orderItems;
            public List<Item> OrderItems
            {
                get 
                {
                    if (orderItems == null)
                        orderItems = new List<Item>();
                    return orderItems; 
                }
            }
        }
        public class Item
        {
            public Guid ID { get; set; }
            public string ItemName { get; set; }
        }
