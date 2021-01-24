    class ShoppingCart
    {
        public IList<CartLine> Items { get; } = new List<CartLine>();
        public ShoppingCart() {}
    }
