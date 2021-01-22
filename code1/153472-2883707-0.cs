    [Test]
    public Get_Product_Does_Not_Modify_Owner() {
        Product mockProduct = mockery.NewMock<Product>(MockStyle.Transparent);
        Stub.On(_productRepositoryMock)
            .Method("GetProduct")
            .Will(Return.Value(mockProduct);
        Expect.Never
              .On(mockProduct)
              .SetProperty("Owner");
        _productService.GetProduct(0);
        mockery.VerifyAllExpectationsHaveBeenMet();
    }
