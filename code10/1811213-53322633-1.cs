    [TestClass]
    public class MServiceTests {   
        [TestMethod]
        public void Get_Users_ReturnsUserList() {
            //Arrange 
            var expected = new List<FUser>() {
                //populate with some users
            };
            var mockRepository = new  Mock<IMRepository>();
            mockRepository.Setup(_ => _.ExecuteCommandReader()).Returns(expected);
            
            var mService = new MService(mockRepository.Object);
    
            //Act
            var resultList = mService.GetFUser();
    
            //Assert
            Assert.IsTrue(resultList.Count > 0);    
        }
    }
