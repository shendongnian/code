    public abstract class Event
    {
        public string Description { get; private set;}
        public DateTime Time { get; protected set; }
        protected Event(string description, DateTime time) {
            this.Description = description;
            Time = time;
        }
    }
