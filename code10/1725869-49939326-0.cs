    public async virtual Task Test_GetEntitiesAsyncBySQL() {
        //Arrange
        var id = "100";
        string queryString = "SELECT * FROM c WHERE c.ID = " + id;
        var dataSource = new List<Book> {
            new Book { ID = "100", Title = "abc"}
        }.AsQueryable();
        Expression<Func<Book, bool>> predicate = t => t.ID == id;
        var expected = dataSource.Where(predicate.Compile());
        var response = new FeedResponse<Book>(expected);
        var mockDocumentQuery = new Mock<IFakeDocumentQuery<Book>>();
        mockDocumentQuery
            .SetupSequence(_ => _.HasMoreResults)
            .Returns(true)
            .Returns(false);
        mockDocumentQuery
            .Setup(_ => _.ExecuteNextAsync<Book>(It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);
        //Note the change here
        mockDocumentQuery.As<IQueryable<Book>>().Setup(_ => _.Provider).Returns(dataSource.Provider);
        mockDocumentQuery.As<IQueryable<Book>>().Setup(_ => _.Expression).Returns(dataSource.Expression);
        mockDocumentQuery.As<IQueryable<Book>>().Setup(_ => _.ElementType).Returns(dataSource.ElementType);
        mockDocumentQuery.As<IQueryable<Book>>().Setup(_ => _.GetEnumerator()).Returns(() => dataSource.GetEnumerator());
        var client = new Mock<IDocumentClient>();
        //Note the change here
        client
            .Setup(_ => _.CreateDocumentQuery<Book>(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<FeedOptions>()))
            .Returns(mockDocumentQuery.Object);
        var documentsRepository = new DocumentDBRepository<Book>(client.Object, "100", "100");
        //Act
        var entities = await documentsRepository.RunQueryAsync(queryString);
        //Assert
        entities.Should()
            .NotBeNullOrEmpty()
            .And.BeEquivalentTo(expected);
    }
