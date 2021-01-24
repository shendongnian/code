    public class Foo : IFoo
    {
        private readonly ILogger<Foo> _logger;
    
        public Foo(ILogger<Foo> logger)
        {
            _logger = logger;
        }
    
        public Task WriteMessage(string message)
        {
            _logger.LogInformation("Foo.WriteMessage called. Message:{MESSAGE}", message);
    
            return Task.FromResult(0);
        }
    }
