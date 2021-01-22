     public class RoomBooking : Entity, IBooking
    {
        public virtual Client Client { get; set; }
        public virtual Address Address { get; set; }
        public virtual IList<BookingPeriod> BookingPeriods { get; set; }
    }
    public class RoomBookingMap : EntityMap<RoomBooking>
    {
        public RoomBookingMap()
        {
            Map(x => x.Client);
            Map(x => x.Address);
            HasManyToMany(x => x.BookingPeriods);
        }
    }
    public class BookingPeriod : Entity
    {
        public virtual IEnumerable<IBooking> Bookings { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
    public class BookingPeriodgMap : EntityMap<BookingPeriod>
    {
        public BookingPeriodgMap()
        {
            Map(x => x.StartTime);
            Map(x => x.EndTime);
            HasManyToMany<RoomBooking>(x => x.Bookings);
        }
    }
     public class EntityMap<T> : ClassMap<T> where T : Entity
        {
            public EntityMap()
            {
                Id(x => x.Id)
                    .UnsavedValue(-1)
                    .Column("id");
    
            }
    
    
        }
