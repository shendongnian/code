    
    public class Status
    {
        public string Name { get; set; }
    }
    public class Fields2
    {
        public Status Status { get; set; }
    }
    public class InwardIssue
    {
        public Fields2 Fields { get; set; }
    }
    public class Issuelink
    {
        public InwardIssue InwardIssue { get; set; }
    }
    public class Fields
    {
        public List<Issuelink> Issuelinks { get; set; }
    }
    public class RootObject
    {
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }
