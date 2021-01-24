    public class PurpleAirData
    {
        public PurpleAirData(DateTime createdAt, double airQuality)
        {
            this.CreatedAt = createdAt;
            this.AirQuality = airQuality;
        }
        // Required properties
        public DateTime CreatedAt { get; set; }
        public double AirQuality { get; set; }
        // Optional properties, thus nullable
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
    }
    public class RootObject
    {
        public Channel channel { get; set; } // Define this using http://json2csharp.com/
        public List<PurpleAirData> feeds { get; set; }
    }
