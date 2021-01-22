    [Test]
    public void Someone_over_65_does_not_pay_a_pension_contribution() {
        Mock<IPensionService> mockPensionService = new Mock<IPensionService>();
        Person p = new Person("test", 66);
        PensionCalculator calc = new PensionCalculator(mockPensionService.Object);
        calc.PayPensionContribution(p);
        mockPensionService.Verify(ps => ps.Pay(It.IsAny<decimal>()), Times.Never());
    }
