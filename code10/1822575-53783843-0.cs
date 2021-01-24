    public class ReservationModel
    {
        // Add the same properties that are in the Reservation class in 
        // the DAL to this class. The properties below are just for example
        public int ReservationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
    }
