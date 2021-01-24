    [TestClass]
    public class BitmapServiceTest {
        [TestMethod]
        public void BitmapService_Should_SaveBitmapAsPngImage() {
            //Arrange
            var mockedStream = Mock.Of<Stream>();
            mockedStream.SetupAllProperties();
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock
                .Setup(_ => _.OpenOrCreateFileStream(It.IsAny<string>()))
                .Returns(mockedStream);
            var sut = new BitmapService(fileSystemMock.Object);
            var renderBitmap = new Canvas();
            var path = new Uri("//A_valid_path");
            //Act
            sut.SaveBitmapAsPngImage(path, renderBitmap);
            //Assert
            Mock.Get(mockedStream).Verify(_ => _.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()));
        }
    }
