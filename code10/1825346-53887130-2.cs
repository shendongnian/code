    public class YourClass
    {
        private readonly ILogger _logger;
        public YourClass(ILogger logger)
        {
            _logger = logger;
        }
        private void MethodThatDoesWhatever()
        {
            try
            {
                // do something
            }
            catch(Exception ex)
            {
                _logger.Log(ex.ToString());
            }
        }
    }
