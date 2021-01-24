    class ProductManagement : IProduct
    {
        public Inventory inventory = new Inventory();
        public void addProduct(Product product)
        {
            inventory.AddProduct(product);
        }
        public void productSold(Product product)
        {
            //TODO: consider accepting quantitySold as a parameter, as you could sell more than 1 quantity of the same product
            var quantitySold = 1;
            inventory.UpdateProduct(product._id, quantitySold);
        }
    }
    class Inventory
    {
        private List<Product> _products = new List<Product>();
        public Inventory()
        {
            
        }
        public void AddProduct(Product product)
        {
            //TODO: add checks if product already exists
            _products.Add(product);
        }
        public void UpdateProduct(int id, int quantity)
        {
            //TODO: check if id is valid
            var product = _products.Single(x => x._id == id);
            product._quantity -= quantity;
        }
    }
