    public class CalendarItem
    {
        public Event Event { get; private set; }
        public EventCategory EventCategory { get; private set; }
        public Category Category { get; private set; }
        public EventParticipant EventParticipant { get; private set; }
        public Participant Participant { get; private set; }
        public CalendarItem(Event event,
                            EventCategory eventCategory,
                            Category category,
                            EventParticipant eventParticipant,
                            Participant participant)
        {
            Event = event;
            EventCategory = eventCategory;
            Category = category;
            EventParticipant = eventParticipant;
            Participant = participant;
        }
    }
