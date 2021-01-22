    /// <summary>
    /// The EventService instance
    /// </summary>
    public class EventService : IEventService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ILoggerFacade logger;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="eventAggregator">The event aggregator instance.</param>
        public EventService(IEventAggregator eventAggregator, ILoggerFacade logger)
        {
            this.logger = logger;
            this.eventAggregator = eventAggregator;
        }
    
        #region IEventService Members
    
        /// <summary>
        /// Publishes the event of type TMessageType to all subscribers
        /// </summary>
        /// <typeparam name="TMessageType">The message type (Payload), must inherit CompositeEvent</typeparam>
        public void Publish<TMessageType>() where TMessageType : BaseEventMessage<TMessageType>, new()
        {
            TMessageType message = Activator.CreateInstance<TMessageType>();
    
            this.Publish(message);
        }
    
        /// <summary>
        /// Publishes the event of type TMessageType to all subscribers
        /// </summary>
        /// <typeparam name="TMessageType">The message type (Payload), must inherit CompositeEvent</typeparam>
        /// <param name="message">The message to publish</param>
        public void Publish<TMessageType>(TMessageType message) where TMessageType : BaseEventMessage<TMessageType>, new()
        {
            // Here we can log our message publications
            if (this.logger != null)
            {
               // logger.log etc.. 
            }
            this.eventAggregator.GetEvent<TMessageType>().Publish(message);
        }
    
        /// <summary>
        /// Subscribes to the event of type TMessage
        /// </summary>
        /// <typeparam name="TMessageType">The message type (Payload), must inherit CompositeEvent</typeparam>
        /// <param name="action">The action to execute when the event is raised</param>
        public void Subscribe<TMessageType>(Action<TMessageType> action) where TMessageType : BaseEventMessage<TMessageType>, new()
        {
            // Here we can log our message publications
            if (this.logger != null)
            {
               // logger.log etc.. 
            }
            this.eventAggregator.GetEvent<TMessageType>().Subscribe(action);
        }
    
        #endregion
    }
