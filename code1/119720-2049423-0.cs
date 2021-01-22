    public void UpdateProductInfo(ProductInfo product)
        {
            var productToUpdate = this.ProductSearchResults.Where(p => p.ID == product.ID).;
    
            if (productUpdate.Count() > 0)
            {
                var toUpdate = productToUpdate.First<ProductInfo>();
    
                this.ProductSearchResults.Remove(toUpdate);
                this.ProductSearchResults.Add(product);
            }
        }
