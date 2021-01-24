    public class Observation
    {
        public string abnormalflag { get; set; }
        public string analytename { get; set; }
        public string value { get; set; }
    }
    public class Example
    {
        public string assignedto { get; set; }
        public string createduser { get; set; }
        public string departmentid { get; set; }
        public List<Observation> observations { get; set; }
        public List<object> pages { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
    }
