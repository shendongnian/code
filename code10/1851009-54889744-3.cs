    public class SomethingTest{
        private readonly ILogger logger = TestFactory.CreateLogger();
        [Fact]
        public async Task Http_Respond_On_Valid_Data() {
            //Arrange
            var expected = "XKCD";
            var mock = new Mock<ISomeDependency>();
            mock.Setup(_ => _.dbCall()).ReturnsAsync(expected);
            Something.Factory = () => return mock.Object;
            var postParam = new Dictionary<string, StringValues>();
            postParam.Add("param", "value");
            var request = new DefaultHttpRequest(new DefaultHttpContext()){
                Query = new QueryCollection(postParam)
            };
            //Act
            var response = (OkObjectResult)await Something.Run(request, logger);
            string actual = (String) response.Value;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
