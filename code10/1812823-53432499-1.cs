    [TestClass]
    public class MyTestClass {
        [Test]
        public async Task __WebApi_Dates_Should_Match() {
            //Arrange
            var date = "22-Nov-18 12:00:00 AM";
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var httpServer = new HttpServer(config);
            var client = new HttpClient(httpServer);
            //Act
            var response = await client.GetAsync("http://localhost/api/test/data");
            var returnJson = await response.Content.ReadAsStringAsync();
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var result = JsonConvert.DeserializeObject<IEnumerable<Model>>(returnJson);
            result.First()
                .Should().NotBeNull()
                .And.Match<Model>(_ => _.Date == date);
        }
    }
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController {
        [HttpGet]
        [Route("data")]
        public IHttpActionResult Get() {
            var date = "22-Nov-18 12:00:00 AM";
            var dtoObject = new[] { new DTO { Date = date } };
            return Ok(dtoObject);
        }
    }
