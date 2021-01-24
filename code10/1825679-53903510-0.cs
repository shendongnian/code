    public class Buienradar
    {
        public string copyright { get; set; }
        public string terms { get; set; }
    }
    
    public class Dayhistory
    {
        public DateTime timestamp { get; set; }
        public double temperatureMin { get; set; }
        public double temperatureMax { get; set; }
        public double groundtemperatureMin { get; set; }
        public double sunshineHours { get; set; }
        public double windgustsMax { get; set; }
        public double windspeedMax { get; set; }
        public int windspeedBftMax { get; set; }
        public int windDirectionDegreesMax { get; set; }
    }
    
    public class Stationmeasurement
    {
        public int stationid { get; set; }
        public string stationname { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string regio { get; set; }
        public DateTime timestamp { get; set; }
        public Dayhistory dayhistory { get; set; }
    }
    
    public class Actual
    {
        public List<Stationmeasurement> stationmeasurements { get; set; }
    }
    
    public class RootObject
    {
        public Buienradar buienradar { get; set; }
        public Actual actual { get; set; }
    }
