    public class ReasonCodeList
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }
    }
    
    public class AppointmentReasonList
    {
        public string ClassCode { get; set; }
        public string ClassDescription { get; set; }
        public bool Active { get; set; }
        public bool IsPatientRelated { get; set; }
        public List<ReasonCodeList> ReasonCodeList { get; set; }
    }
    
    public class RootObject
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<AppointmentReasonList> AppointmentReasonList { get; set; }
    }
    var root = JsonConvert.DeserializeObject<RootObject>(json);
    foreach (var appointmentReason in root.AppointmentReasonList)
    {
        foreach (var reasonCode in appointmentReason.ReasonCodeList)
        {
            Console.WriteLine($"Code: {reasonCode.Code}; Description {reasonCode.Description}");
        }
    }
