    [TestClass]
    public class MyTestClass {
        [Test]
        public async Task __WebApi_Should_Match_Route() {
            //Arrange
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var httpServer = new HttpServer(config);
            var client = new HttpClient(httpServer);
            //Act
            var response = await client.GetAsync("http://localhost/api/test/age?param=28");
            var returnJson = await response.Content.ReadAsStringAsync();
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var result = JsonConvert.DeserializeObject<int>(returnJson);
            result.Should().Be(29);
        }
    }
    [RoutePrefix("api/test")]
    public class TestController : ApiController {
        [Route("name")]
        public string Get(string param) {
            return param + 1;
        }
        [Route("age")]
        public int Get(int param) {
            return param + 1;
        }
    }
