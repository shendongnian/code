         /// <summary>
    /// Background Service which creates the JSON Files for the machine
    /// </summary>
    public class JsonDataCreator : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger functionallity</param>
        public JsonDataCreator(ILogger<JsonDataCreator> logger)
        {
            _logger = logger;
        }
    
    
        /// <summary>
        /// Task which is executed Asynchronous
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for stopping the Task</param>
        /// <returns>Task Completed</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting");
            while(true){
                //Do the business logic
                //Wait the time you want
            }
            return Task.CompletedTask;
        }
    
    
    
        /// <summary>
        /// Stops the Task
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Task Completed</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping");
            Console.WriteLine("Timed Background Service is stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    
        /// <summary>
        /// Disposes the Task
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
