    [TestMethod]
    public void TestProducts()
    {
        var options = new DbContextOptionsBuilder<ElectronicsContext>()
            .UseInMemoryDatabase(databaseName: "Products Test")
            .Options;
    
        using(var context = new ElectronicsContext(options))
        {
            context.Products.Add(new Product {ProductId = 1, ProductName = "TV", ProductDescription = "TV testing",ImageLocation = "test"});
            context.SaveChanges();
        }
    
        using(var context = new ElectronicsContext(options))
        {
            // run your test here
    
        }
    }
