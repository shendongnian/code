    public partial class Product
    {
        public string Category
        {
            get { return this.Category.Description; }
            set { this.Category.Description = value; }
        }
    }
