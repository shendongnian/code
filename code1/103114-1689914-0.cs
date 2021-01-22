    [XmlRoot()]
    public class Settings
    {
        private static Settings instance = new Settings();
        /// <summary>
        /// Access the Singleton instance
        /// </summary>
        [XmlElement]
        public static Settings Instance
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [XmlAttribute]
        public int Height { get; set; }
    
        /// <summary>
        /// Main window status (Maximized or not)
        /// </summary>
        [XmlAttribute]
        public FormWindowState WindowState
        {
            get;
            set;
        }
    
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Settings"/> is offline.
        /// </summary>
        /// <value><c>true</c> if offline; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool IsSomething
        {
            get;
            set;
        }
    
        /// <summary>
        /// Save setting into file
        /// </summary>
        public static void Serialize()
        {
            // Create the directory
            if (!Directory.Exists(AppTmpFolder))
            {
                Directory.CreateDirectory(AppTmpFolder);
            }
    
            using (TextWriter writer = new StreamWriter(SettingsFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(writer, Settings.Instance);
            }
        }
    
        /// <summary>
        /// Load setting from file
        /// </summary>
        public static void Deserialize()
        {
            if (!File.Exists(SettingsFilePath))
            {
                // Can't find saved settings, using default vales
                SetDefaults();
                return;
            }
            try
            {
                using (XmlReader reader = XmlReader.Create(SettingsFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    if (serializer.CanDeserialize(reader))
                    {
                        Settings.instance = serializer.Deserialize(reader) as Settings;
                    }
                }
            }
            catch (System.Exception)
            {
                // Failed to load some data, leave the settings to default
                SetDefaults();
            }
        }
    }
