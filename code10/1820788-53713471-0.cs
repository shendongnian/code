     public class Meeting
    {
        public string MeetingCentre { get; set; }
        public string MeetingRoom { get; set; }
        public Dictionary<string, Reservation> ReservationSchedule { get; set; }
    }
    public class Reservation
    {
        public string From { get; set; }
        //Other properties
    }
