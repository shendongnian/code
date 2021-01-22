        public void save_new_connection()
        {
          string ConStrng = ConfigurationManager.ConnectionStrings.ToString();
          ConnectionStringSettings conSetting = new ConnectionStringSettings();
  
          conSetting.ConnectionString="server=localho;UserId=root;password=mypass;database=night_anglecourier"; 
          conSetting.Name = "courier.Properties.Settings.night_anglecourierConnectionString";
          conSetting.ProviderName = "MySql.Data.MySqlClient";
          System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection conSettings = (ConnectionStringsSection)config.GetSection("connectionStrings");
            conSettings.ConnectionStrings.Remove(conSetting);
            conSettings.ConnectionStrings.Add(conSetting);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
