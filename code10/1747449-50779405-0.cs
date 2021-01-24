    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void getJoiningDateMock() {
            //Arrange
            var expected = DateTime.Now;
            var employeeMock = new Mock<Employee>();
            employeeMock
                .Setup(x => x.getDateOfJoining(It.IsAny<int>()))
                .Returns(expected);
            var objEmp = employeeMock.Object;
            //Act
            var actual = objEmp.getDateOfJoining(1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
