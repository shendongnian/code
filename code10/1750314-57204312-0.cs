    var expected = new List<AgentDetails>
            {
                new AgentDetails
                {
                    Usid = usid, AgentId = agentId
                }
            };
            var dataSource = expected.AsQueryable();
            var response = new FeedResponse<AgentDetails>(dataSource);
            var mockDocumentQuery = new Mock<IFakeDocumentQuery<AgentDetails>>();
            mockDocumentQuery
                .Setup(q => q.ExecuteNextAsync<AgentDetails>(It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);
            mockDocumentQuery
                .SetupSequence(q => q.HasMoreResults)
                .Returns(true)
                .Returns(false);
            var provider = new Mock<IQueryProvider>();
            provider
                .Setup(_ => _.CreateQuery<AgentDetails>(It.IsAny<Expression>()))
                .Returns(mockDocumentQuery.Object);
            mockDocumentQuery.As<IQueryable<AgentDetails>>().Setup(x => x.Provider).Returns(provider.Object);
            mockDocumentQuery.As<IQueryable<AgentDetails>>().Setup(x => x.Expression).Returns(dataSource.Expression);
            mockDocumentQuery.As<IQueryable<AgentDetails>>().Setup(x => x.ElementType).Returns(dataSource.ElementType);
            mockDocumentQuery.As<IQueryable<AgentDetails>>().Setup(x => x.GetEnumerator()).Returns(dataSource.GetEnumerator);
            _mockClient
                .Setup(c => c.CreateDocumentQuery<AgentDetails>(It.IsAny<Uri>(), It.IsAny<FeedOptions>()))
                .Returns(mockDocumentQuery.Object);
 
