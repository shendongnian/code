            try
            {
                Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
                string appPath = UriAssemblyFolder.LocalPath;
                 //Open the configuration file and retrieve 
                 //the connectionStrings section.
                Configuration config = ConfigurationManager.
                    OpenExeConfiguration(appPath + @"\" + exeConfigName);
                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;
