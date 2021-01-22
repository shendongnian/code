        [TestMethod]
        public void ParserWorksWithCalcultaroProxy()
        {
            var calculatorProxyMock = new Mock<ICalculatorProxy>();
            Func<Calculator, Func<int, int, int>> addMock = c => c.Add;
            calculatorProxyMock.Setup(x => x.BinaryOperation(It.Is<Func<Calculator, Func<int, int, int>>>(m => m(_calculator) == addMock(_calculator)), 2, 2))
                                      .Returns(4).Verifiable();           
            var mathParser = new MathParser(calculatorProxyMock.Object);
            mathParser.ProcessExpression("2 + 2");
            calculatorProxyMock.Verify();
        }
