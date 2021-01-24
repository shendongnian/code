    public class Database {
        public string HostName { get; set; }
        // and the rest
    }
    public class ConfigurationManager {
        public Database Database { get; private set; }
        public void Init() {
           // The rest of the Init code
           Database = new Database { 
               HostName = xml.SelectSingleNode("settings/database/hostname").InnerXml
           }
        }
    }
