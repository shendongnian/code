    public class ProductManagement
    {
        public Inventory inventory;
    
        public ProductManagement(Inventory inv)
        {
            this.inventory = inv;
        }
    
        public void productSold(Product product)
        {
            var quantitySold = 1;
            inventory.UpdateProduct(product._id, quantitySold);
        }
    }
