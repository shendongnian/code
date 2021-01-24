    private HttpClient GetHttpClientWithHttpMessageHandlerSequenceResponseMock(List<Tuple<HttpStatusCode,HttpContent>> returns)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var handlerPart = handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .SetupSequence<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               );
            foreach (var item in returns)
            {
                handlerPart = AdddReturnPart(handlerPart,item.Item1,item.Item2);
            }
            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };
            return httpClient;
        }
        private ISetupSequentialResult<Task<HttpResponseMessage>> AdddReturnPart(ISetupSequentialResult<Task<HttpResponseMessage>> handlerPart,
            HttpStatusCode statusCode, HttpContent content)
        {
            return handlerPart
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = statusCode, // HttpStatusCode.Unauthorized,
                   Content = content //new StringContent("[{'id':1,'value':'1'}]"),
               });
        }
