    public class Seat
    {
        public char SeatRow { get; set; }
        public byte SeatNum { get; set; }
        public SeatState State { get; set; }
        public Seat(char row, byte seat, SeatState state)
        {
            this.SeatRow = row;
            this.SeatNum = seat;
            this.State = state;
        }
    }
    public enum SeatState
    {
        Empty,
        ReservedNotPaid,
        ReservedNotPaidMember,
        Paid,
        PaidMemberRate
    }
