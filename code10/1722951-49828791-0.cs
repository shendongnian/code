        public class AppointmentReason
        {
            public string ClassCode { get; set; }
            public string ClassDescription { get; set; }
            public bool Active { get; set; }
            public bool IsPatientRelated { get; set; }
            public List<ReasonCode> ReasonCodeList { get; set; }
        }
