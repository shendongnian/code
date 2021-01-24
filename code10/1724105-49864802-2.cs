    public class CustomOutput : IOutput {
        private static Lazy<CustomOutput> instance = 
            new Lazy<CustomOutput>(() => return new CustomOutput());
        private Lazy<ILogger> logger;
        private Lazy<IMyRepository> repository;
        
        private CustomOutput() { }
        
        public static CustomOutput Instance {
            get {
                return instance.Value;
            }
        }
        
        public void Configure(Lazy<ILogger> logger, Lazy<IMyRepository> repository) {
            this.logger = logger;
            this.repository = repository
        }
        public Task SendEventsAsync(IReadOnlyCollection<EventData> events, long transmissionSequenceNumber, CancellationToken cancellationToken) {
            //TODO: Add null check and fail if not already configured.
        
            foreach (var e in events) {
                logger.Value.LogDebug("event...");
                repository.Value.SaveEvent(e);
                //...;
            }
            return Task.CompletedTask;
        }
    }
    
    public class CustomOutputFactory : IPipelineItemFactory<CustomOutput> {
        public CustomOutput CreateItem(IConfiguration configuration, IHealthReporter healthReporter) {
            return CustomOutput.Instance;
        }
    }
    
    
