     public class Event
        {
                public int Year { get; set; }
                public string Name { get; set; }
                public static Event[] GetEvents()
                {
                    return new Event[]        
                    {
                    new Event{ Name="Event1", Year=2001},
                    new Event{ Name="Event2", Year=2002},
                    new Event{ Name="Event3", Year=2003},
    
                    new Event{ Name="Event4", Year=2001},
                    new Event{ Name="Event5", Year=2002},
                    new Event{ Name="Event6", Year=2003},
    
                    new Event{ Name="Event7", Year=2001},
                    new Event{ Name="Event8", Year=2002},
                    new Event{ Name="Event9", Year=2003}
                };
    
            }
     }
    
     public class Program
      {
          static void Main(string[] args)
            {
    
                var groupedEvents = Event.GetEvents().GroupBy(e => e.Year);
    
                foreach (var groupedEvent in groupedEvents)
                {
                    Console.WriteLine("Year:{0}",groupedEvent.Key);
                    foreach (var evnt in groupedEvent)
                    {
                        Console.WriteLine("---- Event Name:{0}",evnt.Name);
                    }
            }
    
    
       }
    }
