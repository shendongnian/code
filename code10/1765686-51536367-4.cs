       public class MainObject
    {
        public string cdn_url { get; set; }
        public string vimeo_api_url { get; set; }
        public Request request { get; set; }
        public Video video { get; set; }
    }
    
    public class Request
    {
        public Files files { get; set; }
    }
    
    public class Files
    {
        public Progressive[] progressive { get; set; }
    }
    
    public class Progressive
    {
        public string url { get; set; }
    }
    
    public class Video
    {
        public Thumbs thumbs { get; set; }
    }
    public class Thumbs
    {
        public string _640 { get; set; }
    }
