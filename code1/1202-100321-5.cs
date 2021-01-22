    public class MyWebService
    {
        public static DateTime StartTime;
    
        static MyWebService()
        {
            MyWebService.StartTime = DateTime.Now;
        }
    
        public TimeSpan Uptime
        {
            get { return DateTime.Now - MyWebService.StartTime; }
        }
    }
