    public class Pair
    {
        public Pair()
        {
            Guardian = new Guardian();
            Patient = new Patient();
        }
    
        [JsonIgnore]
        public Guardian Guardian { get; set; }
    
        [JsonIgnore]
        public Patient Patient { get; set; }
    
        [JsonProperty(PropertyName = "guardian_id")]
        public int GuardianID
        {
            get { return Guardian.ID; }
            set { Guardian.ID = value; }
        }
    
        [JsonProperty(PropertyName = "guardian_name")]
        public string GuardianName
        {
            get { return Guardian.Name; }
            set { Guardian.Name = value; }
        }
    
        [JsonProperty(PropertyName = "patient_id")]
        public int PatientID
        {
            get { return Patient.ID; }
            set { Patient.ID = value; }
        }
    
        [JsonProperty(PropertyName = "patient_name")]
        public string PatientName
        {
            get { return Patient.Name; }
            set { Patient.Name = value; }
        }
    }
    
