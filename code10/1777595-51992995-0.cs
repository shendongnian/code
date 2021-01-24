        static void Main(string[] args)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            List<FakeAppointments> dateTimesFromDatabase = new List<FakeAppointments>();
            var datesBetweenStartDateAndEndDate = dateTimesFromDatabase.Where(p => p.SnapshotTime >= startDate && p.SnapshotTime <= endDate).ToList();
            int sum = datesBetweenStartDateAndEndDate.Sum(p => p.AvailableSlots);
            Console.ReadKey();
        }
        public class FakeAppointments
        {
            public DateTime SnapshotTime;
            public int AvailableSlots;
        }
