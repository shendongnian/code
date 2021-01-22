    public class Employee
    {
        public string Name { get; set; }
        // other important info
        private List<WorkTime> _availability = new List<WorkTime>();
        public List<WorkTime> Availability
        {
            get { return _availability; }
            internal set { _availability = value; }
        }
    }
    public class WorkTime
    {
        public DayOfWeek Day { get; private set; }
        public int StartHour { get; private set; }
        public int EndHour { get; private set; }
        public WorkTime(DayOfWeek day, int startHour, int endHour)
        {
            // validation here (e.g. day and time range during store hours, start<end, etc.)
            Day = day;
            StartHour = startHour;
            EndHour = endHour;
        }
    }
