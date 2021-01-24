    [Fact]
    public void test_GetBookByBookId() {
        //Arrange
        //Mock IHttpContextAccessor
        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var context = new DefaultHttpContext();
        var fakeTenantId = "abcd";
        context.Request.Headers["Tenant-ID"] = fakeTenantId;
        mockHttpContextAccessor.Setup(_ => _.HttpContext).Returns(context);
        //Mock HeaderConfiguration
        var mockHeaderConfiguration = new Mock<IHeaderConfiguration>();
        mockHeaderConfiguration
            .Setup(_ => _.GetTenantId(It.IsAny<IHttpContextAccessor>()))
            .Returns(fakeTenantId);
        var book = new Book(mockHttpContextAccessor.Object, mockHeaderConfiguration.Object);
        var bookId = "100";
        //Act
        var result = book.GetBookByBookId(bookId);
        //Assert
        result.Result.InterestingMomentsCollection.Should().NotBeNull().And.
            BeOfType<List<InterestingMomentsResponseModel>>();
    }
