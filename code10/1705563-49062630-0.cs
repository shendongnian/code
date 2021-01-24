    public class VehicleResponse { // I'm sure you can come up with a more appropriate name
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        [JsonProperty("value")]
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
