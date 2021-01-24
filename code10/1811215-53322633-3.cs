    [TestClass]
    public class MServiceTests {   
        [TestMethod]
        public void Get_Users_ReturnsUserList() {
            //Arrange 
            var expected = new List<FUser>() {
                //populate with some users
            };
            IMRepository mockRepository = new  Mock<IMRepository>();
            mockRepository.Setup(_ => _.ExecuteCommandReader()).Returns(expected);
            
            IMService mService = new MService(mockRepository.Object);
    
            //Act
            var resultList = mService.GetFUser();
    
            //Assert
            Assert.IsTrue(resultList.Count > 0);    
        }
    }
