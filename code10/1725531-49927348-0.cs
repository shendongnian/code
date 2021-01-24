    public class Rootobject
    {
        public Reports reports { get; set; }
    }
    
    public class Reports
    {
        public Report report { get; set; }
    }
    
    public class Report
    {
        public string id { get; set; }
        public RootStep step { get; set; }
    }
    
    public class RootStep
    {
        public string id { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Step>))]
        public List<Step> step { get; set; }
    }
    
    public class Step
    {
        public string id { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Step>))]
        public List<Step> step { get; set; }
    }
