    public class Models.PatientOverviewViewModel {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
    
    public class Areas.Patient.Models.PatientDetailsViewModel {
        public PatientOverviewViewModel Overview { get; set; }
        public string MobilePhone { get; set; }
    }
