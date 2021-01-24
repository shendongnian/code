        public bool DetermineIfSnakeCase()
        {
            var path = Environment.CurrentDirectory;
            var directory = Path.GetDirectoryName(path);
            var file = Path.GetFileName(path);
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(Path.GetFullPath(directory + Path.DirectorySeparatorChar + file))
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return Convert.ToBoolean(config.AppSettings.Settings["SnakeCase"].Value);
        }
