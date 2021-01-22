    public class Settings
    {
        public static string ConfigFile{get{return "Config.XML";}}
        public string Property1 { get; set; }
        /// <summary>
        /// Saves the settings to the Xml-file
        /// </summary>
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (TextWriter reader = new StreamWriter(ConfigFile))
            {
                serializer.Serialize(reader, this);
            }
        }
        /// <summary>
        /// Reloads the settings from the Xml-file
        /// </summary>
        /// <returns>Settings loaded from file</returns>
        public static Settings Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (TextReader reader = new StreamReader(ConfigFile))
            {
                return serializer.Deserialize(reader) as Settings;
            }
        }
    }
