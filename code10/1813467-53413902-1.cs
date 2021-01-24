    public interface IRow
    {
        IReadOnlyList<Seat> Seats {get;}
    }
    public class Stadium
    {
        private List<Row> _rows = new List<Row>();
        public IReadOnlyList<IRow> Rows => _rows;
        public void AddSeat(Seat seat, int rowNum) => _rows[rowNum].AddSeat(seat);
        private class Row : IRow
        {
             private List<Seat> _seats = new List<Seat>();
             public IReadOnlyList<Seat> Seats => _seats;
             public void AddSeat(Seat seat) => _seats.Add(seat);
        }
    }
