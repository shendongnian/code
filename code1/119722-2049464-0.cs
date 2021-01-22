    public void UpdateProductInfo(ProductInfo product)
    {
        var productToUpdate = this.ProductSearchResults.FirstOrDefault(p => p.ID == product.ID).;
        if (productToUpdate == null)
        {
            // throw exception?
        }
        else
        {
            productToUpdate.Price = productInfo.Price; // for example
        }
    }
