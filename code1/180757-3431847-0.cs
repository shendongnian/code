        [DataContract(Namespace="http://schemas.datacontract.org/2004/07/InboundIntegration.HL7Messaging")]
        public class Message {
    
            public Message() {
                InsuranceList = new List<Insurance>();
                MessageId = GuidComb.NewGuid();
            }
    
            [IgnoreDataMember]
            public Guid MessageId { get; private set; }
    
            #region "Data"
            [DataMember]
            public string MessageTypeIndicator { get; set; }
            [DataMember]
            public MessageConfiguration MessageConfiguration { get; set; }
            [DataMember]
            public Patient Patient { get; set; }
            [DataMember]
            public Encounter Encounter { get; set; }
            [DataMember]
            public IList<Insurance> InsuranceList { get; set; }
            #endregion
    
    THen insurance class looks like this:
     [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/InboundIntegration.HL7Messaging")]
        public class Insurance {
            [DataMember]
            public string ExternalPayerId { get; set; } 
            [DataMember]
            public string PayerName { get; set; }
            [DataMember]
            public string GroupNumber { get; set; }
            [DataMember]
            public string MemberIdOfPatient { get; set; }
            [DataMember]
            public string PatientRelationshipToInsuredIndicator { get; set; }
            [DataMember]
            public string CoordinationOfBenefitsPrecedenceIndicator { get; set; }
