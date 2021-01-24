    public class QueueProcessorFactory : IQueueProcessorFactory
    {
        private readonly IEventTriggerQueuedEventService _qeueuedEventService;    
        private readonly ILogger _logger;    
        private readonly IEventTriggerActionGroupLogService _eventTriggerActionGroupLogService;
        // etc...
    
        public QueueProcessorFactory(
            IEventTriggerQueuedEventService qeueuedEventService,
            ILogger logger,
            IEventTriggerActionGroupLogService eventTriggerActionGroupLogService,
            /* etc... */)
        {
            _qeueuedEventService = qeueuedEventService;
            _logger = logger;
            _eventTriggerActionGroupLogService = eventTriggerActionGroupLogService;
            // etc...
        }
    
        public IQueueProcessor Create()
        {
            return new QueueProcessor(
                _qeueuedEventService,
                _logger,
                _eventTriggerActionGroupLogService,
                /* etc... */);
        }
    }
