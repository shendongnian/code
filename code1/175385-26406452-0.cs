    public class Order : IComparable<Order> {
        public int CompareTo( Order that ) {
            if ( that == null ) return 1;
            if ( this.OrderDate > that.OrderDate) return 1;
            if ( this.OrderDate < that.OrderDate) return -1;
            return 0;
        }
    }
    // in the client code
    // assume myOrders is a populated List<Orders>
    myOrders.Sort(); 
