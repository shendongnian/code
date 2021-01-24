    public class Event
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventDisplayOptions DisplayOptions { get; set; }
    }
    public class EventDisplayOptions
    {
        public Color DateBackgroundColor { get; set; }
        public Color SomeOtherFieldColor {get; set; }
    }
