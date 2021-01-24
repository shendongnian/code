    class Program
        {
            static void Main()
            {
                var root = new RootObject() { customer_number = "Cnum", route_stops = new List<RouteStop>() };
                var routeStops = new List<RouteStop>
                {
                    new RouteStop
                    {
                        company = "My Company",
                        contact = new Contact{ name = "Fname Lname", phone="0000000000" }
                    }
                };
    
                root.route_stops = routeStops;
                
                string output = JsonConvert.SerializeObject(root);
    
                Console.ReadKey();
            }
        }
    
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
