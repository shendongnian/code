    public void PostRequestWithSingleProductTest()
    {
        int? productId = 1;
        var value = new { productId };
        //assuming _productController already created and injected with dependency
        var response = _productController.Post(value);
        Assert.IsNotNull(response);
    }
