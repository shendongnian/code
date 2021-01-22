    public class NewReservation
    {
        public SelectList AvailableServiceDates { get; set; }
        public IEnumerable<DateTime> SelectedServiceDates { get; set; }
    }
