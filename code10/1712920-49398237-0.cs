    public class Doctor
    {
        // other primitive type properties
    
        // since EF is used, ForeignKeyAttribute may be used here
        [ForeignKey("Specialization")]
        public int SpecializationID { get; set; }
    
        public virtual Specialization Specialization { get; set; }
    }
