    public class Rootobject
    {
        public Geocoded_Waypoints[] geocoded_waypoints { get; set; }
    }
    
    public class Geocoded_Waypoints
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }
