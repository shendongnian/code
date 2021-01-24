    public class ShoppingCart : List<CartLine>
    {
        // implement constructors you want available
        public ShoppingCart(){}
        public ShoppingCart( IEnumerable<CartLine> collection ) : base( collection ) {}
        public ShoppingCart( int capacity ) : base( capacity ) {}
        // the benefit here is you can add useful properties
        // if CartLine had a price you could add a Total property, for example:
        public decimal Total => this.Sum( cl => cl.Quantity * cl.Price );
    }
