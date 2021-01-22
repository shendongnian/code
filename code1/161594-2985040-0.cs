    [TestMethod]
    public void DoTheCalculation_DoesWhateverItShouldDo() {
         Mock<ICalculator> calcMock = new Mock<ICalculator>();
         CalculationParameters params = new CalculationParmeters(1, 2);
         params.DoTheCalculation(calcMock.Object);
         calcMock.Verify(c => c.Calculate(It.Is<CalculationParameters>(
                             c => c.LeftHandSide == 1 
                                  && c.RightHandSide == 2));
    }
