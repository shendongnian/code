    public class DomainEventHandlingsExecutor : IDomainEventHandlingsExecutor
    {
        private readonly IEventDispatcher _domainEventDispatcher;
    
        public DomainEventHandlingsExecutor(IEventDispatcher domainEventDispatcher)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }
    
        public void Execute(IEnumerable<IEntity> domainEventEntities)
        {
            foreach (var entity in domainEventEntities)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var @event in events)
                {
                    _domainEventDispatcher.Dispatch(@event);
                }
            }
        }
    }
