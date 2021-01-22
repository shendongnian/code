    // If you're not a purist, go ahead and verify all the attributes in a single
    // test - Get_Product_Does_Not_Modify_The_Product_Returned_By_The_Repository
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
