            System.Configuration.ExeConfigurationFileMap fileMap = new System.Configuration.ExeConfigurationFileMap();
            if (System.IO.File.Exists(String.Format("./{0}.config", Environment.MachineName)))
                fileMap.ExeConfigFilename = String.Format(@"./{0}.config", Environment.MachineName);
            else
                fileMap.ExeConfigFilename = "live.config";
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, System.Configuration.ConfigurationUserLevel.None);
