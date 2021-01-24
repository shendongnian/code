    public class VersionData
    {
        public string version_value { get; set; }
    }
    
    public class Version
    {
        public List<VersionData> version_data { get; set; }
    }
    
    public class RootObject
    {
        public Version version { get; set; }
    }
