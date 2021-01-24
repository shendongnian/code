    public class Person
    {
        public int Id { get; set; }
        // each person have many events
        public List<EventRelation> Events { get; set; }
    }
    public class EventRelation
    {
        public int Id { get; set; }
        public Events Event { get; set; }
        // Person Id forgen Key
        public int Person_Id { get; set; }
        // Events Id forgen Key
        public int Event_Id { get; set; }
    }
    public class Events
    {
        public int Id { get; set; }
        public string EventType { get; set; }
    }
