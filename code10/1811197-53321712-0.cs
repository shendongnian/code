    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Currency { get; set; }
        List<Product> Products { get; set; }
        public Product(int id, string name, double currency)
        {
            this.Id = id;
            this.Name = name;
            this.Currency = currency;
            this.Products = new List<Product>();
        }
        // ...
    }
