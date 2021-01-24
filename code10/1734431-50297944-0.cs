	[Fact(DisplayName = "GetBook")]
	public void GetBook()
	{
		// Arrange
		var mockBook1 = new Mock<BookDto>(Behavior = MockBehavior.Strict);
		var mockBook2 = new Mock<BookDto>(Behavior = MockBehavior.Strict);
		var mockRepository = new Mock<IBPDRepository>(Behavior = MockBehavior.Strict);
		mockRepository.Setup(r => r.GetBook(It.Is<int>(1)).Returns(mockBook1.Object)
		var mockMapper = new Mock<IAutoMapper>(Behavior = MockBehavior.Strict);
		mockMapper.Setup(m => m.Map<BookDto>(mockBook1.Object)).Returns(mockBook2.Object);
		
		// You might have to change the constructor.
		var sut = new BooksController(mockRepository.Object, mockMapper.Object);
		IActionResult actionResult;
		
		// Act
		actionResult = sut.GetBook(1);
		
		var actualBook = actionResult.Model as BookDto;
		// Assert
		Assert.Equal(mockBook2.Object, actualBook);
	}
