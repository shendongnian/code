            // somewhere in your test class
            public interface IFakeDocumentQuery<T> : IDocumentQuery<T>, IOrderedQueryable<T>
            {
            }
            // somewhere in your unit test
            var expected = new List<YourType>
            {
                new YourType
                {
                    yourField = "yourValue"
                }
            };
            var mockDocumentClient = new Mock<IDocumentClient>();
            var dataSource = expected.AsQueryable();
            var response = new FeedResponse<YourType>(dataSource);
            var mockDocumentQuery = new Mock<IFakeDocumentQuery<YourType>>();
     
            // the part that gets the work done :)
            var provider = new Mock<IQueryProvider>();
            provider
                .Setup(p => p.CreateQuery<YourType>(It.IsAny<Expression>()))
                .Returns(mockDocumentQuery.Object);
            mockDocumentQuery
                .Setup(q => q.ExecuteNextAsync<YourType>(It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);
            mockDocumentQuery
                .SetupSequence(q => q.HasMoreResults)
                .Returns(true)
                .Returns(false);
            mockDocumentQuery
                .As<IQueryable<YourType>>()
                .Setup(x => x.Provider)
                .Returns(provider.Object);
            mockDocumentQuery
                .As<IQueryable<YourType>>()
                .Setup(x => x.Expression)
                .Returns(dataSource.Expression);
            mockDocumentQuery
                .As<IQueryable<YourType>>()
                .Setup(x => x.ElementType)
                .Returns(dataSource.ElementType);
            mockDocumentQuery
                .As<IQueryable<YourType>>()
                .Setup(x => x.GetEnumerator())
                .Returns(dataSource.GetEnumerator);
            mockDocumentClient
                .Setup(c => c.CreateDocumentQuery<YourType>(It.IsAny<Uri>(), It.IsAny<FeedOptions>()))
                .Returns(mockDocumentQuery.Object);
