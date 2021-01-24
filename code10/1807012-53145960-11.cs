    public class OrderLine
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        protected bool Equals(OrderLine other)
        {
            return string.Equals(Sku, other.Sku) && Quantity == other.Quantity;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderLine) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Sku != null ? Sku.GetHashCode() : 0) * 397) ^ Quantity;
            }
        }
    }
