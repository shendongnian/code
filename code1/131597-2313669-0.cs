    string sectionName = "applicationSettings/" + 
                appName + ".Properties.Settings";
             System.Configuration.ClientSettingsSection section = 
                (System.Configuration.ClientSettingsSection)
                 System.Configuration.ConfigurationManager.GetSection(sectionName);
             foreach (SettingElement setting in section.Settings)
             {
                string value = setting.Value.ValueXml.InnerText;
                string name = setting.Name;
                if (name.ToLower().StartsWith(searchName.ToLower()))
                {
                   return value;
                }
             }
