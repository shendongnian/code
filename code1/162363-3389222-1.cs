    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }
        public results[] results { get; set; }
    
    }
    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }
    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }
    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
