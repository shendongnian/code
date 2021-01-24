    public static class DomainEventHandler
    {
        public static ILifetimeScope _container { get; set; }
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            foreach (var handler in _container.Resolve<IEnumerable<IHandle<T>>>())
            {
                handler.Handle(args);
            }
        }
    }
