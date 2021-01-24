    public class ShoppingCart : List<CartLine>
    {
        // implement constructors you want available
        public ShoppingCart(){}
        public ShoppingCart( IEnumerable<CartLine> collection ) : base( collection ) {}
        public ShoppingCart( int capacity ) : base( capacity ) {}
    }
