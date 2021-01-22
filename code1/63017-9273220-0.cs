    string ConStrng = ConfigurationSettings.AppSettings["ConnectionString"];
                string sss = "Data Source=";
                string xxx = ";Initial Catalog=AlfalahScholarship;Integrated Security=True";
                //ConfigurationSettings.AppSetting;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Get the appSettings section.
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                appSettings.Settings.Remove("ConnectionString");
                appSettings.Settings.Add("ConnectionString", sss + txtServerName.Text + xxx);
    
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
