    public class CalendarEntry
    {
        public int CalendarEntryId { get; private set; }
        // .. Other properties...
    
        public virtual Customer Customer { get; private set; }
        public virtual List<CalendarEvent> Events { get; private set; } = new List<CalendarEvent>();
    }
