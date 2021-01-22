    [TestMethod()]
    public void AddProductTest()
    {
        CatalogController target = new CatalogController(/*testing variables*/);
        target.AddProduct(new Product { /* product details for testing */ });
        
        // Test the results
    }
