    public interface IProduct
    {
        public int Id  { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public int FreeQuantity { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountOffered { get; set; }
        public double TotalBilled { get; set; }
    }
