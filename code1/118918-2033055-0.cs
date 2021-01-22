    public class MyConfig {  
        static MyConfig configuration = new MyConfig();    
        public static MyConfig Configuration { return configuration; }
    
        readonly string version;
        public string Version { get { return version; } }
    
        MyConfig() { version = "0.1"; }
    }
