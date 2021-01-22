    [Serializable]
    [DataContract(Namespace = "")]    
    public class SomeClass
    {
        [DataMember]
        public string FirstName
        { 
            get; set;
        }
        [DataMember]
        public string LastName
        { 
            get; set;
        }
        [DataMember]
        private IDictionary<long, string> customValues;
        public IDictionary<long, string> CustomValues
        {
            get { return customValues; }
            set { customValues = value; }
        }
    }
