        string my404Setting;
        // Get the application configuration file.
        System.Configuration.Configuration config =
            ConfigurationManager.OpenExeConfiguration(
            ConfigurationUserLevel.None);
    
        foreach (ConfigurationSectionGroup sectionGroup in config.SectionGroups)
        {
            if (sectionGroup.type == "customErrors" )
            {
                foreach (ConfigurationSections section in sectionGroup.Sections)
                {
                   if (section.StatusCode = "404")
                   {
                      my404Setting = section.Redirect;
                      break;
                   }
                }
                break; 
            }
        }
    }
