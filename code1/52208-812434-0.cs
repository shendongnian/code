    [DataContract]
    public class DataObject {
        
        string propertyName;
    
        [DataMember]
        public string PropertyName {
            get { return propertyName; }
            set { propertyName = value; }
        }
    }
