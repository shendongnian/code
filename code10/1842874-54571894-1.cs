    class Bookings : IList<Booking>, IReadonlyList<Booking>, IReadonlyCollection<Booking>
    {
        public Bookings()
        {
            this.bookings = new List<Booking>();
        }
     
        public Bookings(IEnumerable<Booking> bookings)
        {
            this.bookings = bookings.ToList();
        }
        private readonly IList<Booking> bookings;
        public int Count => this.booking.Count;
        public void Add(Booking booking) {this.booking.Add(booking);}
        public void Remove(Booking booking) {this.booking.Remove(booking);}
        public IEnumerator<Booking> GetEnumerator() {return this.booking.GetEnumerator();}
        etc.
    }
