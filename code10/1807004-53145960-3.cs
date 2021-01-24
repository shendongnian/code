    public class OrderLineEqualityComparer : IEqualityComparer<OrderLine>
    {
        public bool Equals(OrderLine x, OrderLine y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Sku, y.Sku) && x.Quantity == y.Quantity;
        }
        public int GetHashCode(OrderLine obj)
        {
            unchecked
            {
                return ((obj.Sku != null ? obj.Sku.GetHashCode() : 0) * 397) ^ obj.Quantity;
            }
        }
    }
