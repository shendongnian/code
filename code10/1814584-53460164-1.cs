        public class OrderContext : DbContext
        {
            public DbSet<Order_Master> Order_Master { get; set; }
            public DbSet<Order_Item> Order_Items { get; set; }
            // More entities...
        }
        public class Order_Item
        {
            public int Id { get; set; }
            public string Item_Description { get; set; }
            // More properties...
        }
        public class Order_Master
        {
            public Order_Master()
            {
                Order_Item = new List<Order_Item>();
            }
            public ICollection<Order_Item> Order_Item { get; set; }
            public int Id { get; set; }
            public string Order_Description { get; set; }
            // More properties...
        }
