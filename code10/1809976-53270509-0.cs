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
            // Events for the day with an OrderBy clause on the EventDateTime property
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
            // Get two lists ordered by EventDateTime - one for JS and another for JE
            var jsEvents = events.Where(e => e.EventType == "JS").ToList();
            var jeEvents = events.Except(jsEvents).ToList();
            // Starting with the JS list, output one item
            // from each list, alternating between them
            int counter;
            for (counter = 0; counter < jsEvents.Count; counter++)
            {
                Console.WriteLine(jsEvents[counter]);
                if (jeEvents.Count > counter) Console.WriteLine(jeEvents[counter]);
            }
            // Output the rest of the JE events if there are any
            for (; counter < jeEvents.Count; counter++)
            {
                Console.WriteLine(jeEvents[counter]);
            }
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
