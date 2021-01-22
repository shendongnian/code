    public class MyWebService
    {
        public static DateTime StartTime = DateTime.Now;
    
        public TimeSpan Uptime
        {
            get { return DateTime.Now - MyWebService.StartTime; }
        }
    }
