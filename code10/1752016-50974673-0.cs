    [WMIClass("Win32_Processor")]
    public class Processor
    {
        [WMIIgnore]
        public string NonRequiredProp { get; set; }
        public string Name { get; set; }
        [WMIProperty("NumberOfCores")]
        public int Cores { get; set; }
        public string Description { get; set; }
    }
