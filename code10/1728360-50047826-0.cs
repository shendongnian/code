    [Test]
    public void CreateNewTemplateTest() {
        //Arrange
        var salesRepId = 68,
        var priceAdvanced = (decimal)22.33,
        var priceComplete = (decimal)44.33,
        var priceMvr = (decimal)6.33,
        var setupFee = (decimal)2.33,
        //Act
        OnlineSignupModel model = new OnlineSignupModel {
            SalesRepId = salesRepId,
            PriceAdvanced = priceAdvanced,
            PriceComplete = priceComplete,
            PriceMvr = priceMvr,
            SetupFee = setupFee,
        };
        //Assert
        Assert.That(
            model.SalesRepId = salesRepId &&
            model.PriceAdvanced == priceAdvanced &&
            model.PriceComplete == priceComplete &&
            model.PriceMvr == priceMvr &&
            model.SetupFee == setupFee, Is.True);
    }
