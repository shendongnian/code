    [TestMethod]
    public void DeleteProductWillDeleteProductFromRepository()
    {
        // Fixture setup
        var fixture = new ServiceFixture();
        var id = fixture.CreateAnonymous<int>();
        var repMock = fixture.FreezeMoq<ProductRepository>();
        var sut = fixture.CreateAnonymous<ProductManagementService>();
        // Exercise system
        sut.DeleteProduct(id);
        // Verify outcome
        repMock.Verify(r => r.DeleteProduct(id));
        // Teardown
    }
