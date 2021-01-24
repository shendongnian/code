    public class Rootobject
    {
        public string URL { get; set; }
        public string Method { get; set; }
        public Dictionary<int, Parameter> Parameters { get; set; }
    }
    public class Parameter
    {
        public string VersionName { get; set; }
        public string TestCycleName { get; set; }
    }
    
