    public class PatientProperties : EntityModel
    {
        [Key]
        public long ID { get; set; }
    
        public long PatientID { get; set; }
    
        [ForeignKey("PatientID")]
        public Patient Patients { get; set; }
    
        public long? CancerTypeID { get; set; }
        [ForeignKey("CancerTypeID")]
        public CancerType CancerType { get; set; }
    
        public long? DietaryID { get; set; }
        [ForeignKey("DietaryID")]
        public Dietary Dietary { get; set; }
    }
