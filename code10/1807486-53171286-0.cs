    public class ProductRepository
        {
            Dictionary<int, Product> products = Product.GetProduct();
            public void UpdateProducts(IEnumerable<Product> updatedProducts)
            {
                foreach(var productToUpdate in updatedProducts)
                {
                    UpdateProduct(productToUpdate);
                }
                ///update code here...
            }
            public void UpdateProduct(Product productToUpdate)
            {
                // get the product with ID 1234 
                var product = products[productToUpdate.ProductId];
                ///update code here...
            }
        }
