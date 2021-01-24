    public class Event
    {
        public string EventType { get; set; }
        public DateTime? EventDateTime { get; set; }
        public override string ToString()
        {
            return $"{EventDateTime}  {EventType}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // Events for the day ordered by EventDateTime
            var events = new List<Event>
            {
                new Event {EventType = "JE",
                    EventDateTime = DateTime.Parse("10/21/2018 12:23 PM")},
                new Event {EventType = "JE",
                    EventDateTime = DateTime.Parse("10/21/2018 2:29 PM")},
                new Event {EventType = "JE",
                    EventDateTime = DateTime.Parse("10/21/2018 2:40 PM")},
                new Event {EventType = "JS",
                    EventDateTime = DateTime.Parse("10/21/2018 2:15 PM")},
                new Event {EventType = "JS",
                    EventDateTime = DateTime.Parse("10/21/2018 3:12 AM")},
                new Event {EventType = "JS",
                    EventDateTime = DateTime.Parse("10/21/2018 12:12 PM")},
            }.OrderBy(e => e.EventDateTime.Value);
            var lastEventType = events.Any(e => e.EventType == "JS") 
                ? "JE" : "JS";
            foreach (var e in events)
            {
                // Indicate errors with red text
                Console.ForegroundColor = e.EventType == lastEventType
                    ? ConsoleColor.Red
                    : ConsoleColor.Gray;
                Console.WriteLine(e);
                lastEventType = e.EventType;
            }
            Console.ResetColor();
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
