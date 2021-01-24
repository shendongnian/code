      public class Person
        {
            public int Id { get; set; }
    
            // each person have many events
            public List<Event> Events { get; set; }
        }
    
        public class Event
        {
            public int Id { get; set; }
    
            public string EventType { get; set; }
    
            // Person Id forgen Key
            public int Person_Id { get; set; }
    
        }
