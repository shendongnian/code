    [WebMethod(EnableSession = true)]
    public PatientsResult GetPatientList(bool returnInactivePatients) {
        if (!IsLoggedIn()) {
            return new PatientsResult() {
                Success = false,
                LoggedIn = false,
                Message = "Not logged in"
            };
        }
        Func<IEnumerable<PatientResult>, IEnumerable<PatientResult>> filterActive = 
            patientList => returnInactivePatients ? patientList : patientList.Where(p => p.Status == "Active");
        User u = (User)Session["user"];
        return new PatientsResult() {
            Success = true,
            LoggedIn = true,
            Message = "",
            Patients = filterActive((from p in u.Practice.Patients
                          select new PatientResult() {
                              PhysicianID = p.PhysicianID,
                              Status = p.Active ? "Active" : "Inactive",
                              PatientIdentifier = p.PatientIdentifier,
                              PatientID = p.PatientID,
                              LastVisit = p.Visits.Count > 0 ? p.Visits.Max(v => v.VisitDate).ToShortDateString() : "",
                              Physician = (p.Physician == null ? "" : p.Physician.FirstName + " " + p.Physician == null ? "" : p.Physician.LastName).Trim(),
                          })).ToList<PatientResult>()
        };
    }
    public class Result {
        public bool Success { get; set; }
        public bool LoggedIn { get; set; }
        public string Message { get; set; }
    }
    public class PatientsResult : Result {
        public List<PatientResult> Patients { get; set; }
    }
    public class PatientResult  {
        public int PatientID { get; set; }
        public string Status { get; set; }
        public string PatientIdentifier { get; set; }
        public string Physician { get; set; }
        public int? PhysicianID {get;set;}
        public string LastVisit { get; set; }
    }
}
