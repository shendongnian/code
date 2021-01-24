    public class Program
    {
        static void Main(string[] args)
        {
            var shiftScheduler = new ShiftScheduler(new DateTime(2018, 01, 01));
            var requestedShift = shiftScheduler.GetShift(new DateTime(2018, 01, 05));
            Console.WriteLine(requestedShift.IsWorkDay
              ? $"Scheduled from ${requestedShift.HoursBegin}{requestedShift.MinutesBegin:00} " +
                $"to {requestedShift.HoursEnd}{requestedShift.MinutesEnd:00}"
              : "No work today");
        }
    }
    public class Shift
    {
        public Shift(int hoursBegin, int hoursEnd, int minutesBegin, int minutesEnd, bool isWorkDay)
        {
            HoursBegin = hoursBegin;
            HoursEnd = hoursEnd;
            MinutesBegin = minutesBegin;
            MinutesEnd = minutesEnd;
            IsWorkDay = isWorkDay;
        }
        public int HoursBegin { get; set; }
        public int HoursEnd { get; set; }
        public int MinutesBegin { get; set; }
        public int MinutesEnd { get; set; }
        public bool IsWorkDay { get; set; }
    }
    public class ShiftScheduler
    {
        private readonly Dictionary<int, Shift> _shifts = new Dictionary<int, Shift>();
        private readonly DateTime _startDate;
        public ShiftScheduler(DateTime startDate)
        {
            Initialize();
            _startDate = startDate;
        }
        private void Initialize()
        {
            _shifts.Add(0, new Shift(6, 14, 0, 0, true)); // Day 1
            _shifts.Add(1, new Shift(14, 22, 0, 0, true)); // Day 2
            _shifts.Add(2, new Shift(22, 6, 0, 0, true)); // Day 3
            _shifts.Add(3, new Shift(0, 0, 0, 0, false)); // Day 4, day off
            _shifts.Add(4, new Shift(0, 0, 0, 0, false)); // Day 5, day off
        }
        public Shift GetShift(DateTime targetDate)
        {
            int days = (int)Math.Floor((targetDate - _startDate).TotalDays);
            if (days < 0)
            {
                throw new ArgumentException("Target date prior to start date.");
            }
            Shift targetShift;
            _shifts.TryGetValue(days % _shifts.Count, out targetShift);
            return targetShift;
        }
    }
