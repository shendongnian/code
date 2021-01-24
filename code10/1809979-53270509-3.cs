    public class Event
    {
        public string EventType { get; set; }
        public DateTime? EventDateTime { get; set; }
        public override string ToString()
        {
            return $"{EventDateTime}: {EventType}";
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
            }.OrderBy(e => e.EventDateTime);
            // Initialize lastEventType to the opposite of the type of event we 
            // expect to see first (which is "JS" unless there are no "JS" events)
            var lastEventType = events.Any(e => e.EventType == "JS")
                ? "JE" : "JS";
            foreach (var e in events)
            {
                var errorMessage = string.Empty;
                // Check for error
                if (e.EventType == lastEventType)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Create an error message
                    var error = e.EventType == "JS"
                        ? "JS before JE"
                        : "JE before JS";
                    var dateStr = e.EventDateTime?.ToShortDateString() ?? "[null date]";
                    errorMessage = $" - On {dateStr} this error occurred: [{error}]";
                    // Your code would include:
                    // errorList.Add(errorMessage); 
                    // errorListRow.Add(dc);
                }
                Console.WriteLine(e + errorMessage);
                Console.ResetColor();
                // Update the lastEventType with this event type
                lastEventType = e.EventType;
            }
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
