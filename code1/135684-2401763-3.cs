    namespace hcgames.ObjectClasses.ShoppingCart 
    { 
        [Serializable] 
        public class ShoppingCartItem 
        {
            public ShoppingCartItem(); 
            public ShoppingCartItem(DataRow dr); 
            public IEnumerable<ShoppingCartCartAddon> Addons { get; set; } 
            public string CartID { get; set; } 
            public int ID { get; set; } 
            public string Image { get; set; } 
            public string Name { get; set; } 
            public string Price { get; set; } 
            public long ProductID { get; set; } 
            public int Quantity { get; set; } 
            public decimal Weight { get; set; } 
        }
    }
