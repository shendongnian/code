    [WMIClass("Win32_NetworkAdapterConfiguration")]
    public class NetworkAdapterConfiguration
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public uint IPConnectionMetric { get; set; }
        public UInt32 InterfaceIndex { get; set; }
        public string WINSScopeID { get; set; }
    }
