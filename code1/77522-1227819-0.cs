    public class Booking
    {
        private static int BookingCount = 1;
        public Booking()
        {
           Id = BookingCount++;
        }
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
