    public class TestClass {
        private MyController _controller;
        public TestClass() {
          _controller = new MyController (); 
        }
    
        [Fact]
        public void Upload_WhenCalled() {
            //Arrange
            var content = File.OpenRead(@"C:\myfile.xlsx");
            var file = new Mock<IFormFile>();
            file.Setup(_ => _.OpenReadStream()).Returns(content);
    
            //Act
            var result = _controller.UploadFile(file.Object);
    
            //Assert
            //...
        }
    }
