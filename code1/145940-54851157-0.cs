    public class CartProduct
    {
        public Int32 ID;
        ...
        public CartProduct(Int32 ID, ...)
        {
            this.ID = ID;
            ...
        }
        public override int GetHashCode()
        {
            return ID;
        }
        public override bool Equals(Object obj)
            {
                if (obj == null || !(obj is CartProduct))
                    return false;
                else
                    return GetHashCode() == ((CartProduct)obj).GetHashCode();
            }
    }
