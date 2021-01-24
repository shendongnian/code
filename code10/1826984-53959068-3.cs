    public class CarControllerTests {
        private readonly Mock<ILog> _logMock;
        private readonly Mock<IHttpClientService> _httpClientServiceMock;
        private readonly Mock<IOptions<Config>> _optionMock;
        private readonly CarController _sut;
        public CarControllerTests()  //runs for each test method 
        {
            _logMock = new Mock<ILog>();
            _httpClientServiceMock = new Mock<IHttpClientService>();
            _optionMock = new Mock<IOptions<Config>>();
            _sut = new CarController(_logMock.Object, _httpClientServiceMock.Object, _optionMock.Object);
        }
        [Fact]
        public async Task Post_Returns200() {
            //Arrange
            _httpClientServiceMock
                .Setup(_ => _.PostAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string>>(),
                    It.IsAny<string>())
                )
                .ReturnsAsync(HttpStatusCode.OK);
                
            //Act
            
            //...omitted for brevity
            
            //...
        }
    }
    
