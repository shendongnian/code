    public void PostRequestWithSingleProductTest() {
        //Arrange
        int? productId = 1;
        var value = new { productId };
        //assuming _productController already created and injected with dependency
        //Act
        var response = _productController.Post(value);
        //Assert
        Assert.IsNotNull(response);
    }
