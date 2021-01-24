    public class MyControllerTests {
        [Fact]
        public async Task Upload_WhenCalled() {
            //Arrange
            var content = new MemoryStream();
            var file = new Mock<IFormFile>();
            file.Setup(_ => _.OpenReadStream()).Returns(content);
            var expected = new JArray();
            var service = new Mock<IExcelService>();
            service
                .Setup(_ => _.GetDataAsync(It.IsAny<Stream>()))
                .ReturnsAsync(expected);
            
            var controller = new MyController(service.Object);
            
            //Act
            var result = await controller.UploadFile(file.Object);
    
            //Assert
            service.Verify(_ => _.GetDataAsync(content));
            //...other assertions like if result is OkContentResult...etc
        }
    }
    
