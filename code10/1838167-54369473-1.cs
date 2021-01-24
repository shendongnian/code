    public class ReservationRow
    {
        public int ReservationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationRow(int id, DateTime startDate, DateTime endDate)
        {
            ReservationId = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
