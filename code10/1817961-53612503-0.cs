    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guest> Guests { get; set; }
    }
    
    public class Guest
    {
        public string GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }       
    }
    public interface IEventProvider
    {
        Event[] GetEvents();
    }
