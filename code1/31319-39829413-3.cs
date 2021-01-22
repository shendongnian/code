    public class ConfigFile
    {
        public String guiPath { get; set; }
        public string configPath { get; set; }
        public Dictionary<string, string> mappedDrives {get;set;} 
        
        public ConfigFile()
        {
            mappedDrives = new Dictionary<string, string>();
        }
    }
