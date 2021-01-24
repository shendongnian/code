    [TestClass]
    public class TrainUnitTest
    {
        [TestMethod]
        public void Should_Get_TrainID() {
            //Arrange
            string expected = "1S45";
            Train subject = new Train();
            subject.TrainID = expected;
            
            //Act
            string actual = subject.TrainID;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
    
