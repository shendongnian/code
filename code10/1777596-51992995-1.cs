        static void Main(string[] args)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            List<FakeAppointments> appointmentsFromDatabase = new List<FakeAppointments>();
            var appointmentsBetweenStartDateAndEndDate = appointmentsFromDatabase.Where(p => p.SnapshotTime >= startDate && p.SnapshotTime <= endDate).ToList();
            int sum = appointmentsBetweenStartDateAndEndDate.Sum(p => p.AvailableSlots);
            Console.ReadKey();
        }
        public class FakeAppointments
        {
            public DateTime SnapshotTime;
            public int AvailableSlots;
        }
