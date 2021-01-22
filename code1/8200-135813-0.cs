    public class LogArgs
    {
    
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public Dictionary<string, object> Paramters { get; set; }
    
        
        public LogArgs()
        {
            this.Paramters = new Dictionary<string, object>();
        }
        
    }
