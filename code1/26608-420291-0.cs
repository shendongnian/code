    public class MyChangePersonService : IChangePersonService
    {
        private IList<EventHandler> handlers;
        private EventHandler _personEvent;
        public event EventHandler PersonCreated
        {
            add
            {
                _personEvent += value;
                handlers.Add(value);
            }
            remove
            {
                _personEvent -= value;
                handlers.Remove(value);
            }
        }
        public IList<EventHandler> PersonEventHandlers { get { return handlers; } }
        public MyChangePersonService()
        {
            handlers = new List<EventHandler>();
        }
        public void FirePersonEvent()
        {
            _personEvent(this, null);
        }
    }
