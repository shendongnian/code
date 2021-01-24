    public abstract class EntityBase : IEventSourcable
    {
        ICollection<IEvent> IEventSourcable.History { get; }
    
        void IEventSourcable.ApplyEvent(IEvent e)
        {
            // Do the magic
        }
    
        protected void ApplyEvent(IEvent e)
        {
            (this as IEventSourcable).ApplyEvent(e);
        }
    }
    
    public class User : EntityBase
    {
        public void ApplyEvent(UserCreated e)
        {
            base.ApplyEvent(e);
        }
    }
