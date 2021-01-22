        /// <summary>
        /// Loads the Local App.Config file, and sets it to be the local app.config file
        /// </summary>
        /// <param name="p_ConfigFilePath">The path of the config file to load, i.e. \Logs\</param>
        public void LoadFileAppConfig(string p_ConfigFilePath)
        {
            try
            {
                // The app.config path is the passed in path + Application Name + .config
                m_LocalAppConfigFile = ProcessLocalAppConfig(p_ConfigFilePath + this.ApplicationName + ".config");
                // This sets the service's app.config property
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", m_LocalAppConfigFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
