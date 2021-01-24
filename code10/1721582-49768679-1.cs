    public class Coordinate
    {
        // ...
        [JsonIgnore]
        [Required] // <--
        public string GeofenceID { get; set; }
        //..
    }
