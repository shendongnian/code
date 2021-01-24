    class LoginResponse
    {
        
        [JsonProperty("odata.metadata")]
        public String ODataMetadata { get; set; }
        [JsonProperty("value")]
        public List<Vehicle> Vehicles { get; set; }
    }
    class Vehicle
    {
        // same as before...
    }
    LoginResponse response = JsonConvert.DeserializeObject<Vehicle>( loginJsonString );
    foreach( Vehicle veh in response.Vehicles )
    {
        
    }
