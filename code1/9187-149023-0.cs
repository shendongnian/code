    public class DomainEventStorage<ActionType>
    {
        public List<ActionType> Actions
        {
            get
            {
                var k = string.Format("Domain.Event.DomainEvent.{0}.{1}",
                                      GetType().Name,
                                      GetType().GetGenericArguments()[0]);
                if (Local.Data[k] == null)
                    Local.Data[k] = new List<ActionType>();
                return (List<ActionType>) Local.Data[k];
            }
        }
        public IDisposable Register(ActionType callback)
        {
            Actions.Add(callback);
            return new DomainEventRegistrationRemover(() => Actions.Remove(callback)
                );
        }
    }
    public class DomainEvent<T1> : IDomainEvent where T1 : class
    {
        private readonly DomainEventStorage<Action<T1>> _impl = new DomainEventStorage<Action<T1>>();
        internal List<Action<T1>> Actions { get { return _impl.Actions; } }
        public IDisposable Register(Action<T1> callback)
        {
            return _impl.Register(callback);
        }
        public void Raise(T1 args)
        {
            foreach (var action in Actions)
            {
                action.Invoke(args);
            }
        }
    }
