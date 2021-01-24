    public class Alert
    {
        public string alert;
        public string riskcode;
    }
    
    public class SiteAlerts
    {
        public Site site { get; set; }
    }
    
    public class Site
    {
        public List<Alert> alerts { get; } = new List<Alert>();
    }
