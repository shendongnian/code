    public interface IEntity
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }
    }
    public class Entity<TKey> : IEntity
    {
        public TKey Id { get; private set; }
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;
        …
    }
