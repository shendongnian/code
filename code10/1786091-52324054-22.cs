    public class PressureMap
    {
        public double[,] PressureMatrix { get; set; }
    }
    public class CalibrationConfiguration 
    {
        // Data model not included in question
    }
    public class RepresentationConfiguration 
    {
        // Data model not included in question
    }
    public class RecordedDataHeader
    {
        public string SoftwareVersion { get; set; }
        public CalibrationConfiguration CalibrationConfiguration { get; set; }
        public RepresentationConfiguration RepresentationConfiguration { get; set; }
    }
    public class RecordedData
    {
        // Ensure the header is serialized first.
        [JsonProperty(Order = 1)]
        public RecordedDataHeader RecordedDataHeader { get; set; }
        // Ensure the pressure data is serialized last.
        [JsonProperty(Order = 2)]
        public IEnumerable<PressureMap> PressureData { get; set; }
    }
