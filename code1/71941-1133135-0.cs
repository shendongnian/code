    [Serializable]
    public class EmailConfiguration {
        private string dataBoxID;
        public string DataBoxID {
            get { return dataBoxID; }
            set { dataBoxID = value; }
        }
        private List<string> defaultSendToAddressCollection;
        [XmlArrayItem("EmailAddress")]
        public List<string> DefaultSendToAddressCollection {
            get { return defaultSendToAddressCollection; }
            set { defaultSendToAddressCollection = value; }
        }
        public EmailConfiguration() {
            DefaultSendToAddressCollection = new List<string>();
        }
    }
