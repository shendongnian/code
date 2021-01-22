    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                    configFileMap.ExeConfigFilename = exeConfigName;
                    System.Configuration.Configuration myConfig = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
    
                    ConnectionStringsSection section = myConfig.GetSection("connectionStrings") as ConnectionStringsSection;
    
                    if (section.SectionInformation.IsProtected)
                    {
                        // Remove encryption.
                        section.SectionInformation.UnprotectSection();
                    }
                    else
                    {
                        // Encrypt the section.
                        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }
    
                    myConfig.Save();
