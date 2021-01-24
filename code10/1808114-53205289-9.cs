    public void PostRequestWithSingleProductTest() {
        //Arrange
        var value = new PostProductModel { productId = 1 };
        //assuming _productController already created and injected with dependency
        //Act
        var response = _productController.Post(value) as OkObjectResult;
        //Assert
        Assert.IsNotNull(response);
    }
