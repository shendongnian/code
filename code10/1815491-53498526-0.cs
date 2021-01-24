    public class RootObject
    {
        public IList<Application> Application { get; set; }
        public MailSettings MailSettings { get; set; }
    }
    public class Application
    {
        public string Office { get; set; }
        public List<string> LogPath { get; set; }
    }
    
    public class MailSettings
    {
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
    }
    
    public class RootObject
    {
        public List<Application> Application { get; set; }
        public MailSettings MailSettings { get; set; }
    }
