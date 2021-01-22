    public class Company
    {
        /// <summary>
        /// Company location
        /// </summary>
        public Location Location => new Location(Latitude, Longitude);
    
        // hide from json, but retrieve from solr
        [JsonIgnore, SolrField("latlng_0_coordinate")]
        public double Latitude { get; set; }
    
        // hide from json, but retrieve from solr
        [JsonIgnore, SolrField("latlng_1_coordinate")]
        public double Longitude { get; set; }
    }
