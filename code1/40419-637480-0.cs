    public partial class Cart
    {
            // Make a new cart
            private Cart(int userId, int cartId)
            {
                this.CartId = userId;
                this.UserId = cartId;
            }
            private static Dictionary<int, Cart> CurrentCarts = new Dictionary<int, Cart>();
    
            public static Cart GetCurrentCart(int userId)
            {
                // TODO: Use a proper caching mechanism that will at least
                //       remove old carts from the dictionary.
                Cart cart;
                if (CurrentCarts.TryGetValue(userId, out cart))
                {
                    return cart;
                }
                
                cart = /* try get cart from DB */;
                if (cart == null)
                {
                    // Make a new cart
                    cart = new Cart(userId, GenerateCartId());
                }
                CurrentCarts[userId] = cart;
                return cart;
            }
    }
