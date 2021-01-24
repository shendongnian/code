        public static ShoppingCart GetInstance()
        {
            ShoppingCart cart = (ShoppingCart)Session["MyShoppingCart"];
        
            if (cart == null)
            {
                Session["MyShoppingCart"] = cart = new ShoppingCart();
            }
        
            return cart;
        }
        
        protected ShoppingCart()
        {
            Items = new List<pricetempstorage>();
        } 
    
    
