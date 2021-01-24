    [TestFixture]
    public class CalculatorLogicTests
    {
        // Our unit under test.
        ICalculatorLogic calculatorLogic;
        [SetUp]
        public void SetUp()
        {
            // This method is called for every [Test] in this class.
            // So let's recreate our CalculatorLogic here so that each
            // test has a fresh instance.
            calculatorLogic = new CalculatorLogic();
        }
    
        [Test]
        public void GetSum_WithTwoIntegers_ReturnsTheirSum()
        {
            // Arrange
            int expectedResult = 3 + 3;
    
            // Act
            var sum = calculatorLogic.GetSum(3, 3);
            
            // Assert
            Assert.AreEqual(sum, expectedResult);
        }
    }
