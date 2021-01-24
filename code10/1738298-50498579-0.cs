    public class EventDispatcher : IEventDispatcher
    {
        private readonly ILifetimeScope _lifetimeScope;
    
        public EventDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
    
        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (dynamic handler in GetHandlers(eventToDispatch))
            {
                handler.Handle((dynamic)eventToDispatch);
            }
        }
    
        private IEnumerable GetHandlers<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            return (IEnumerable) _lifetimeScope.Resolve(
                typeof(IEnumerable<>).MakeGenericType(
                    typeof(IHandler<>).MakeGenericType(eventToDispatch.GetType())));
        }
    }
