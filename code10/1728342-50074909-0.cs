    [Test]
    public void ShouldSaveBitmapAsPngImage()
    {
    	// Arrange
    	Uri pathToFile = new Uri("//A_valid_path");
    	IFileSystem fileSystemMock = MockRepository.GenerateStrictMock<IFileSystem>();
    	MockedFileStream mockedFileStream = new MockedFileStream();
    	fileSystemMock.Expect(x => x.OpenOrCreateFileStream(pathToFile.AbsolutePath))
    		.IgnoreArguments().Return(mockedFileStream);
    
    	BitmapService sut = new BitmapService(fileSystemMock);
    	Size renderSize = new Size(100, 50);
    	RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
    		(int)renderSize.Width, (int)renderSize.Height, 96d, 96d, PixelFormats.Pbgra32);
    
    	// Act
    	sut.SaveBitmapAsPngImage(pathToFile, renderBitmap);
    
    	// Assert
    	// Was data was written to it?
    	Assert.That(mockedFileStream.Length, Is.GreaterThan(0));
    
    	mockedFileStream.CustomDispose(); //done with stream
    }
