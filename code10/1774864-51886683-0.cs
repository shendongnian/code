    public class MyTestClass {
        public MyTestClass()  
            myRepository = Substitute.For<IMyRepository>();
        }
    
        [Fact]
        public void My_Test() {
            //Arrange
            myRepository.CheckIfExists(mockObject.Name).Returns(mockObject.Name);
            var myService = new MyService(myRepository);
    
            //Act
            var result = myService.Create(mockObject);
    
            //Assert
            //....check that the returned result is as expected.
        }
    }
