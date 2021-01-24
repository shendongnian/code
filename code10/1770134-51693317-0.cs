    public class App
    {
        public int appid { get; set; }
        public string name { get; set; }
    }
    
    public class Applist
    {
        public List<App> apps { get; set; }
    }
    public class RootObject
    {
        public Applist applist { get; set; }
    }
