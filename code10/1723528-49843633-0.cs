    public class Pid
    {
        public string pid { get; set; }
    }
            
    public class Parameters
    {
        [JsonProperty("Gross Power")]
        public Pid GrossPower { get; set; }
        [JsonProperty("PTO Power")]
        public Pid PTOPower { get; set; }
        [JsonProperty("Power Measured @")]
        public Pid PowerMeasured { get; set; }
        public Pid Displacement { get; set; }
        public Pid Aspiration { get; set; }
    }
    public class Engine
    {
        public string gid { get; set; }
        public Parameters parameters { get; set; }
    }
            
    public class Parameters2
    {
        [JsonProperty("Operating Weight")]
        public Pid OperatingWeight { get; set; }
        [JsonProperty("Fuel Capacity")]
        public Pid FuelCapacity { get; set; }
    }
    public class Operational
    {
        public string gid { get; set; }
        public Parameters2 parameters { get; set; }
    }
                        
    public class Parameters3
    {
        public Pid Type { get; set; }
        [JsonProperty("Number Of Forward Gears")]
        public Pid NumberOfForwardGears { get; set; }
    }
    public class Transmission
    {
        public string gid { get; set; }
        public Parameters3 parameters { get; set; }
    }
    public class RootObject
    {
        public string mid { get; set; }
        public Engine Engine { get; set; }
        public Operational Operational { get; set; }
        public Transmission Transmission { get; set; }
    }
