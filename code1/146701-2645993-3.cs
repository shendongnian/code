    [Test]
    public void TestCalculateReturnsBasicRateTaxForMiddleIncome() {
        // Arrange
        // TaxPolicy is a dependency that we need to manipulate.
        var policy = new Mock<TaxPolicy>();
        bar.Setup(x => x.BasicRate.Returns(0.22d));
        var taxCalculator = new TaxCalculator();
        
        // Act
        // Calculate takes a TaxPolicy and an annual income.  
        var result = taxCalculator.Calculate(policy.Object, 25000);
        // Assert
        // Basic Rate tax is 22%, which is 5500 of 25000.
        Assert.AreEqual(5500, result);
    }  
