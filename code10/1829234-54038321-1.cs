    public class CustomLoggerFactory : ILoggerFactory
    {
        private readonly CustomLoggerProvider _provider;
        public CustomLoggerFactory(ILogger logger = null, bool dispose = false)
        {
            _provider = new CustomLoggerProvider(logger, dispose);
        }
        public void Dispose()
        {
            _provider.Dispose();
        }
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }
    }
