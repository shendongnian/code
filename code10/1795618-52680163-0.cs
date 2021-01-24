    public abstract class Product
    {
        public abstract int Id  { get; set; }
        public abstract string UserId { get; set; }
        public abstract int ProductId { get; set; }
        public abstract int OrderedQuantity { get; set; }
        public abstract int FreeQuantity { get; set; }
        public abstract double TotalPrice { get; set; }
        public abstract double DiscountOffered { get; set; }
        public abstract double TotalBilled { get; set; }
    }
