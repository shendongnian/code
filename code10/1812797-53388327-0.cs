        public class AppDesc
    {
        public string description { get; set; }
        public string message { get; set; }
    }
    
    public class AppName
    {
        public string description { get; set; }
        public string message { get; set; }
    }
    
    public class RootObject
    {
        public AppDesc appDesc { get; set; }
        public AppName appName { get; set; }
    }
