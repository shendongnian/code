    public static List<Cart> GetCartItems(string ShoppingCartID)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                return db.Carts.Include("Album").Where(cart => cart.CartId == ShoppingCartID).ToList();
            }
        }
