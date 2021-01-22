    public class Adapter
    {
        private readonly ISessionableObject _session;
        public Adapter(ISessionableObject session)
        {
            _session = session;
        }
        public void DoSomething()
        {
             var data = _session.Data;
            ...
        }
    }
