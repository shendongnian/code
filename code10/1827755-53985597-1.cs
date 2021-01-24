    public class Contact
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
    
    public class RouteStop
    {
        public string company { get; set; }
        public Contact contact { get; set; }
    }
    
    public class RootObject
    {
        public string customer_number { get; set; }
        public List<RouteStop> route_stops { get; set; }
    }
