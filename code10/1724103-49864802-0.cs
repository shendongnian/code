    public class CustomOutput : IOutput {
        private readonly ILogger logger;
        private readonly IMyRepository repository;
        public CustomOutput(ILogger<CustomOutput> logger,IMyRepository repository) {
            this.logger = logger;
            this.repository = repository
        }
        public Task SendEventsAsync(IReadOnlyCollection<EventData> events, long transmissionSequenceNumber, CancellationToken cancellationToken) {
            foreach (var e in events) {
                logger.LogDebug("event...");
                repository.SaveEvent(e);
                //...;
            }
            return Task.CompletedTask;
        }
    }
    
