    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageLocation { get; set; }
        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public override bool Equals(object obj)
        {
            Product other = (Product)obj;
            return ProductId == other.ProductId && ProductName.Equals(other.ProductName); // or anything else you want to compare
        }
    }
