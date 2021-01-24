    [TestMethod]
    public void InfoTitel_ReturnsProductNameAndPrice()
    {
        var builder = new ProductBuilder();
       
        var product = builder.ProductName("Device X").Price(100).Create();
        product.Info.Title.Should().Be("Device X-100.00 USD");
    }
    [TestMethod]
    public void TotalPrice_CalculatesFromPriceAndQuantity()
    {
        var builder = new ProductBuilder();
       
        var product = builder.Price(35.99m).Quantity(2).Create();
        product.TotalPrice.Should().Be(71.98m);
    }
