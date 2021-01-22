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
        public void AddRange(params LogEvent[] logEvents)
        {
            Array.ForEach(logEvents, AddEvent);
        }
        public void Add(int id, string code)
        {
            AddEvent(new LogEvent(id, code));
        }
        public void Add(int id, string code, string displayFormat)
        {
            AddEvent(new LogEvent(id, code, displayFormat));
        }
        public void Add(LogEvent logEvent)
        {
            _events.Add(logEvent);
        }
        public void Remove(int id)
        {
            _eventList.Remove(_eventList.Where(i => i.id.Equals(id)).SingleOrDefault());
        }
        public void Remove(string code)
        {
            _eventList.Remove(_eventList.Where(i => i.Code.Equals(code)).SingleOrDefault());
        }
        public void Remove(LogEvent logEvent)
        {
            _eventList.Remove(logEvent);
        }
    }
