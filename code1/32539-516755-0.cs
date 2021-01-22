    public abstract class EventHandlerBase<TDetail> : EventHandlerBase    
      where TDetail : Contracts.DeliveryItemEventDetail
    {
      public EventHandlerBase(AbstractRepository data, ILoggingManager loggingManager)
        : base(data, loggingManager)
      {
         // Initialize generic class
      }
    }
