    public class Order
    {
        public int OrderNumber { get; set; }
        public List<OrderLine> Lines { get; set; }
        protected bool Equals(Order other)
        {
            var equals = OrderLinesEquals(Lines, other.Lines);
            return equals;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }
        public override int GetHashCode()
        {
            if (Lines == null)
            {
                return 0;
            }
            unchecked
            {
                int hash = 19;
                foreach (OrderLine item in Lines.OrderBy(x => x.Sku, StringComparer.OrdinalIgnoreCase))
                {
                    hash = hash * 31 + item.GetHashCode();
                }
                return hash;
            }
        }
        private bool OrderLinesEquals(List<OrderLine> x, List<OrderLine> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            bool areEquivalent = x.Count == y.Count && !x.Except(y).Any();
            return areEquivalent;
        }
        public override string ToString()
        {
            return $"Sku: {Sku ?? "[null]"}, Quantity: {Quantity}";
        }
    }
