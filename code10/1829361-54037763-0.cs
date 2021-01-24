    public class DriverMaster
    {
        public string UID { get; set; }
        public string LICENCENO { get; set; }
        public string NAME { get; set; }
    }
    
    public class Root
    {
    	[JsonExtensionData]
    	public IDictionary<string,object> Data {get;set;}
    }
