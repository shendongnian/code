    using ...
    using Moq;
    
    namespace Tests
    {
      [TestFixture]
      public class OrderControllerTest
      {
        public OrderControllerTest()
        {
          var mockLogger = Mock<ILogger<OrderController>>();
          mockLogger.Setup( x => x.LogError( It.IsAny<Exception>(), It.IsAny<string>() );
          _logger = mockLogger.Object;
        }
      ...
      }
    }
