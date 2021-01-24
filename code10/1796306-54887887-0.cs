    public static class TestHelper
    { 
        public static Mock<ILogger<T>> GetMockedLoggerWithAutoSetup<T>()
        {
            var logger = new Mock<ILogger<T>>();
            logger.Setup<object>(x => x.Log(
           It.IsAny<LogLevel>(),
           It.IsAny<EventId>(),
           It.IsAny<object>(),
           It.IsAny<Exception>(),
           It.IsAny<Func<object, Exception, string>>()));
            return logger;
        }
        
        public static void VerifyLogMessage<T>(Mock<ILogger<T>> mockedLogger, LogLevel logLevel, Func<string, bool> predicate, Func<Times> times)
        {
            mockedLogger.Verify(x => x.Log(logLevel, 0, It.Is<object>(p => predicate(p.ToString())), null, It.IsAny<Func<object, Exception, string>>()), times);
        }
    }
--
    public class Dummy
    {
    }
    [Fact]
    public void Should_Mock_Logger()
    {
        var logger = TestHelper.GetMockedLoggerWithAutoSetup<Dummy>();
        logger.Object.LogInformation("test");
        TestHelper.VerifyLogMessage<Dummy>(logger, LogLevel.Information, msg => msg == "test", Times.Once);
    }
