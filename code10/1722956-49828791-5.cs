        public class AppointmentReasonResponse
        {
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public List<AppointmentReason> AppointmentReasonList { get; set; }
        }
        public class AppointmentReason
        {
            public string ClassCode { get; set; }
            public string ClassDescription { get; set; }
            public bool Active { get; set; }
            public bool IsPatientRelated { get; set; }
            public List<ReasonCode> ReasonCodeList { get; set; }
        }
        public class ReasonCode
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public int Duration { get; set; }
            public bool Active { get; set; }
        }
