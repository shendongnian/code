    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
    }
    public class PatientVisit
    {
        public Patient Patient { get; set; }
        public DateTime VisitDate { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Patient p1 = new Patient();
            p1.PatientId = 1;
            p1.Name = "Harry";
            Patient p2 = new Patient();
            p2.PatientId = 2;
            p2.Name = "John";
            List<PatientVisit> visits = new List<PatientVisit>();
            visits.Add(new PatientVisit
            {
                Patient = p1,
                VisitDate = DateTime.Now.AddDays(-5)
            });
            visits.Add(new PatientVisit
            {
                Patient = p1,
                VisitDate = DateTime.Now
            });
            visits.Add(new PatientVisit
            {
                Patient = p2,
                VisitDate = DateTime.Now.AddDays(-1)
            });
            var q = (from t in visits
                     select new
                     {
                         t.Patient.Name,
                         t.Patient.PatientId,
                         t.VisitDate
                     }).OrderByDescending(t=>t.VisitDate).GroupBy(x => new { x.PatientId });
            foreach (var item in q)
            {
                Console.WriteLine(item.FirstOrDefault().Name + ", " + item.FirstOrDefault().VisitDate);
            }
        }
    }
