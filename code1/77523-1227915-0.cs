        public class Booking
        {
            protected Booking() { }
            public int Id { get; set; }
            public string From { get; set; }
            public string To { get; set; }
        }
        public class BookingContextFactory
        {
            private int count;
            public BookingContextFactory() : this(0) { }
            public BookingContextFactory(int startValue) 
            {
                count = startValue;
            }
            public Booking CreateBooking(string from, string to)
            {
                return new InternalBooking { Id = count++, From = from, To = to };
            }
            private class InternalBooking : Booking
            {
                public InternalBooking() : base() { }
            }
        }
