    public class SomeService
    {
        private readonly ILogger _logger; 
        public SomeService(ILogger logger)
        { 
            _logger = logger;
        }
        public void SomeMethod()
        {
            _logger.Log("Some message");
        }
     }
