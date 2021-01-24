    public class SessionTracker : IRegisteredObject
    {
        static readonly SessionTracker Tracker = new SessionTracker();
        private static readonly Dictionary<string, HttpSessionState> _sessions = new Dictionary<string, HttpSessionState>();
        private static readonly object padlock = new object();
        private SessionTracker()
        {
        }
        public void Stop(bool immediate)
        {
            try
            {
                //store them in database
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AddSession(HttpSessionState session)
        {
            lock (padlock)
            {
                _sessions.Add(session.SessionID, session);
            }
        }
        public void RemoveSession(HttpSessionState session)
        {
            lock (padlock)
            {
                _sessions.Remove(session.SessionID);
            }
        }
        public static SessionTracker GetInstance()
        {
            return Tracker;
        }
    }
