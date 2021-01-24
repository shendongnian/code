    public class Seat : Entity
    {
        private Person _person;
        public Seat(SeatNumber id)
        {
            SeatId = id;
        }
        public SeatNumber SeatId { get; }
    
        public void Book(Person person)
        {
            if(_person == person) return;
            if (_person != null)
            {
                throw new InvalidOperationException($"Seat {SeatId} cannot be booked by {person}. {_person} already booked it.");
            }
    
            _person = person;
        }
    
        public bool IsBooked => _person != null;
    }
