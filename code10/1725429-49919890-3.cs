        public static ShoppingCart GetInstance()
        {
            
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
        
            return cart;
        }
        
        protected ShoppingCart()
        {
            Items = new List<pricetempstorage>();
        } 
    
   
