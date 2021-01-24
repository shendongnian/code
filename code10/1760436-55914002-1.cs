    public class ClassThatLogs
    {
        private readonly ILogger<ClassThatLogs> _logger;
        
        public ClassThatLogs(ILogger<ClassThatLogs> logger)
        {
            _logger = logger;
        }
    
        public void DoWork()
        {
            _logger.LogInformation("Working");
        }
    }
