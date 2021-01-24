    public class Patient
    {
        // …
        // option 1
        public CancerType CancerType { get; set; }
        public Dietary Dietary { get; set; }
        public OtherProperty OtherProperty { get; set; }
        // option 2
        public IList<PatientProperty> Properties { get; set; }
    }
