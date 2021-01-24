    [TestFixture]
    public class CalculatorLogicTests
    {
        // This guy we want to test.
        ICalculatorLogic calculatorLogic;
    
        // Our mock!
        Mock<ILogger> loggerMock;
    
        [SetUp]
        public void SetUp()
        {
            // Create the logger mock!
            loggerMock = new Mock<ILogger>();
    
            // Inject the logger into our CalculatorLogic!
            calculatorLogic = new CalculatorLogic(loggerMock.Object);
        }
    
        [Test]
        public void GetSum_WithTwoIntegers_ShouldCallLogger()
        {
            // Arrange
            int expectedResult = 3 + 3;
    
            // Act
            var sum = calculatorLogic.GetSum(3, 3);
    
            // Assert
            Assert.AreEqual(sum, expectedResult);
    
            // Verify that the logger's Log method was called once with x = 3 and y = 3.
            loggerMock.Verify(logger => logger.Log(It.Is<int>(x => x == 3), It.Is<int>(y => y == 3)), Times.Once());
        }
    } 
