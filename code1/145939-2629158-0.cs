    public class CartProduct : IEquatable<CartProduct>
    {
        public Int32 ID;
        public String Name;
        public Int32 Number;
        public Decimal CurrentPrice;
        public CartProduct(Int32 ID, String Name, Int32 Number, Decimal CurrentPrice)
        {
            this.ID = ID;
            this.Name = Name;
            this.Number = Number;
            this.CurrentPrice = CurrentPrice;
        }
        public String ToString()
        {
            return Name;
        }
        public bool Equals( CartProduct other )
        {
            // Would still want to check for null etc. first.
            return this.ID == other.ID && 
                   this.Name == other.Name && 
                   this.Number == other.Number && 
                   this.CurrentPrice == other.CurrentPrice;
        }
    }
