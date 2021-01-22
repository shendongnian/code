    [DataContract]
    public class FormatFault
    {
        private string additionalDetails;
        [DataMember]
        public string AdditionalDetails
        {
            get { return additionalDetails; }
            set { additionalDetails = value; }
        }
    }
