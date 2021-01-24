    public class Odds
    {
        public List<string> h2h { get; set; }
    }
    
    public class Williamhill
    {
        public Odds odds { get; set; }
        public int last_update { get; set; }
    }
    
    public class Sites
    {
        public Williamhill williamhill { get; set; }
    }
    //here the root object is the sites but ofcourse the real root object is events
    public class RootObject
    {
        public Sites sites { get; set; }
    }
    string json = // yourJson
    JObject obj = JObject.Parse(json);
    
    var h2h = obj["events"]["Arsenal_West Ham United"]["sites"]["williamhill"]["odds"]["h2h"];
    foreach (var item in h2h)
    {
       Debug.WriteLine(item);
    }
