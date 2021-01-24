    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Get_ClientReturns404_ThrowsNotFoundException() {
        //Arrange
        var originalException = new Exception("Status code 404");
    
        var response = A.Fake<Nest.IGetResponse<Dictionary<string, object>>>();
        A.CallTo(() => response.OriginalException).Returns(originalException);
    
        var client = A.Fake<Nest.IElasticClient>();
        A.CallTo(() => 
            client.GetAsync<Dictionary<string, object>>(A<IGetRequest>._, A<CancellationToken>._)
        ).Returns(Task.FromResult(response));
    
        var request = new DataGetRequest {
            CollectionName = string.Empty,
            DocumentType = string.Empty,
            DataAccessType = string.Empty
        };
    
        var elasticSearch = new ElasticSearch(null, client);
    
        // Act
        var result = await elasticSearch.Get(request);
    
        // Assert
        Assert.Fail("Should have hit an exception.");
    }
