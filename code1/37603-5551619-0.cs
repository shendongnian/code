    internal sealed partial class Settings
    {
        private List<ConfigurationElement> list;
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            this.OpenAndStoreConfiguration();
        }
        /// <summary>
        /// Opens the dll.config file and reads its sections into a private List of ConfigurationElement.
        /// </summary>
        private void OpenAndStoreConfiguration()
        {
            string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            Uri p = new Uri(codebase);
            string localPath = p.LocalPath;
            string executingFilename = System.IO.Path.GetFileNameWithoutExtension(localPath);
            string sectionGroupName = "applicationSettings";
            string sectionName = executingFilename + ".Properties.Settings";
            string configName = localPath + ".config";
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            // read section of properties
            var sectionGroup = config.GetSectionGroup(sectionGroupName);
            var settingsSection = (ClientSettingsSection)sectionGroup.Sections[sectionName];
            list = settingsSection.Settings.OfType<ConfigurationElement>().ToList();
            // read section of Connectionstrings
            var sections = config.Sections.OfType<ConfigurationSection>();
            var connSection = (from section in sections
                               where section.GetType() == typeof(ConnectionStringsSection)
                               select section).FirstOrDefault() as ConnectionStringsSection;
            if (connSection != null)
            {
                list.AddRange(connSection.ConnectionStrings.Cast<ConfigurationElement>());
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified property name.
        /// </summary>
        /// <value></value>
        public override object this[string propertyName]
        {
            get
            {
                var result = (from item in list
                             where Convert.ToString(item.ElementInformation.Properties["name"].Value) == propertyName
                             select item).FirstOrDefault();
                if (result != null)
                {
                    if (result.ElementInformation.Type == typeof(ConnectionStringSettings))
                    {
                        return result.ElementInformation.Properties["connectionString"].Value;
                    }
                    else if (result.ElementInformation.Type == typeof(SettingElement))
                    {
                        return result.ElementInformation.Properties["value"].Value;
                    }
                }
                return null;
            }
            // ignore
            set
            {
                base[propertyName] = value;
            }
        }
