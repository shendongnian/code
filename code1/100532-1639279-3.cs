    public class EventManager
    {
        private List<LogEvent> _eventList;
        public LogEvent this[string eventCode]
        {
            get
            {
                return _eventList.Where(i => i.Code.Equals(eventCode)).SingleOrDefault();
            }
        }
        public LogEvent this[int id]
        {
            get
            {
                return _eventList.Where(i => i.Id.Equals(id)).SingleOrDefault();
            }
        }
        public EventManager()
        {
            _eventList = new List<LogEvent>()
            {
                new LogEvent(1, "OpeningDatabaseConnection", "Opening database connection to {0}"),
                new LogEvent(2, "ConnectionOpenedSuccessfully", "Database connection to {0} opened successfully."),
                new LogEvent(3, "MoreStuff", "Other format {0} where {1} is needed.")
            };
        }
    }
