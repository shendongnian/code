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
