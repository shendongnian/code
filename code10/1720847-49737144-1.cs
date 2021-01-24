    [TestClass]
    public class BusinessHandlerTests {
        [TestMethod]
        public void BusinessHandler_Should_GetResult() {
            //Arrange
            var fizz = new Mock<IBusinessRule>();
            fizz.Setup(_ => _.IsDivisible(It.IsAny<int>()))
                .Returns((int value) => value % 3 == 0);
            fizz.Setup(_ => _.PrintOutput()).Returns("Fizz");
            var buzz = new Mock<IBusinessRule>();
            buzz.Setup(_ => _.IsDivisible(It.IsAny<int>()))
                .Returns((int value) => value % 5 == 0);
            buzz.Setup(_ => _.PrintOutput()).Returns("Buzz");
            var fizzbuzz = new Mock<IBusinessRule>();
            fizzbuzz.Setup(_ => _.IsDivisible(It.IsAny<int>()))
                    .Returns((int value) => value % 15 == 0);
            fizzbuzz.Setup(_ => _.PrintOutput()).Returns("FizzBuzz");
            var businessRule = new[] { 
                fizzbuzz.Object, fizz.Object, buzz.Object  // <--order is important
            }; 
            var subject = new BusinessHandler(businessRule);
            var inputValue = 15;
            var expected = new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };
            //Act
            var actual = subject.GetResult(inputValue);
            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
    
