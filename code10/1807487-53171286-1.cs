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
                if(products.ContainsKey(productToUpdate.ProductId))
                {
                    var product = products[productToUpdate.ProductId];
                    ///update code here...
                    product.ProductName = productToUpdate.ProductName;
                }
                else
                {
                    //add code or throw exception if you want here.
                    products.Add(productToUpdate.ProductId, productToUpdate);
                }
            }
        }
