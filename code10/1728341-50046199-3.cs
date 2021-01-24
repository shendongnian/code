    [TestMethod]
    public void BitmapService_Should_SaveBitmapAsPngImage() {
        //Arrange
        var mockedStream = new MockedFileStream();
        var fileSystemMock = new Mock<ImageDrawingCombiner3.IFileSystem>();
        fileSystemMock
            .Setup(_ => _.OpenOrCreateFileStream(It.IsAny<string>()))
            .Returns(mockedStream);
        var sut = new ImageDrawingCombiner3.BitmapService(fileSystemMock.Object);
        Size renderSize = new Size(100, 50);
        var renderBitmap = new RenderTargetBitmap(
            (int)renderSize.Width, (int)renderSize.Height, 96d, 96d, PixelFormats.Pbgra32);
        var path = new Uri("//A_valid_path");
        //Act
        sut.SaveBitmapAsPngImage(path, renderBitmap);
        //Assert
        mockedStream.Length.Should().BeGreaterThan(0); //data was written to it.
        mockedStream.CustomDispose(); //done with stream
    }
