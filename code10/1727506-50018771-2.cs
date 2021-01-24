    [Table("orders")]
    class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        
        public bool AddProduct(Product product)
        {
            if(this.Products.Contains(product))
            {
                return false;
            }
            order.Products.Add(product);
            return true;
        }
    }
