    [DataContract]
    public class ExampleResponse
    {
        private System.Collections.Generic.List<int> intValues;
    
        [DataMember]
        public System.Collections.Generic.List<int> IntValues
        {
            get { return intValues; }
            set { intValues = value; }
        }
    }
