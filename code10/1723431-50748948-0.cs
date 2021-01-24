    [WMIClass("Win32_IP4RouteTable")]
    public class RouteTable
    {
        public string Destination{ get; set; }
        public string NextHop{ get; set; }
        public string Mask{ get; set; }
        public string Metric1{ get; set; }
    }
