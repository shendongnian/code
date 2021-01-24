    public class B1
    {
        public string keyNode { get; set; }
        public string value { get; set; }
        public string formula { get; set; }
        public string validationID { get; set; }
        public string measureID { get; set; }
        public string classificationID { get; set; }
        public int nodeID { get; set; }
        public string tabCode { get; set; }
        public int dataCapID { get; set; }
    }
    
    public class B2
    {
        public string keyNode { get; set; }
        public string value { get; set; }
        public string formula { get; set; }
        public string validationID { get; set; }
        public string measureID { get; set; }
        public string classificationID { get; set; }
        public int nodeID { get; set; }
        public string tabCode { get; set; }
        public int dataCapID { get; set; }
    }
    
    public class AdditionalAttributeBlock
    {
        public string blockTitle { get; set; }
        public List<B1> B1 { get; set; }
        public List<B2> B2 { get; set; }
    }
    
    public class RootObject
    {
        public List<AdditionalAttributeBlock> additionalAttributeBlock { get; set; }
    }
