    public void PostRequestWithSingleProductTest() {
        var value = new PostProductModel { productId = 1 };
        //assuming _productController already created and injected with dependency
        var response = _productController.Post(value) as OkContentResult;
        Assert.IsNotNull(response);
    }
