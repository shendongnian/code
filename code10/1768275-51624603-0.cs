    public class People
    {
         public string firstName { get; set; }
         public string lastName { get; set; }
         public List<Event> registeredEvents { get; set; }
         public People()
         {
             registeredEvents = new List<Event>();
         }
    }
    public class Event
    {
         public string name { get; set; }
         public string anyInfo { get; set; }
    }
