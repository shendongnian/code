    [TestClass()]
    public class Class1Test {
        [TestMethod()]
        public async Task GetDataTest() {
            //Arrange
            var mockService = new Mock<Class1>(){
                CallBase = true
            };
            var expected = ReturnTrue(); // this function returns true
            mockService
                .Setup(x => x.DoSomething(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expected);
            //Act
            var actual = await mockService.Object.GetData();
            //Assert
            Assert.IsTrue(actual);
        }
    }
