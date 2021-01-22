    [Test]
    public void GetProduct_GetsProductFromRepository() 
    {
       var product = EntityGenerator.Product();
    
       _productRepositoryMock
         .Setup(pr => pr.GetProduct(product.Id))
         .Returns(product);
    
       Product returnedProduct = _productService.GetProduct(product.Id);
    
       Assert.AreSame(product, returnedProduct);
    }
