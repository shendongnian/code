    public interface IEventStore
    {
        Task<IEnumerable<IDomainEvent>> GetEventsAsync(Guid aggregateId, Type aggregateType);
        Task PersistAsync(IAggregateRoot aggregateRoot, IEnumerable<IDomainEvent> domainEvents);
    }
