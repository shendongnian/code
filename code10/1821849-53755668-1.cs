    class RootObj
    {
        public string somethingone { get; set; }
        public string somethingtwo { get; set; }
        public Information information { get; set; }
    }
    
    class Information
    {
        public Dictionary<string, string>[] report { get; set; }
    }
