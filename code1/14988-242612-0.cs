    static void DisplayMappedExeConfigurationFileSections()
    {
        // Get the application configuration file path.
        string exeFilePath = System.IO.Path.Combine(
            Environment.CurrentDirectory, "ConfigurationManager.exe.config");
        // HERE !!!     
        // Map to the application configuration file.
        ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
        configFile.ExeConfigFilename = exeFilePath;
        Configuration config =
            ConfigurationManager.OpenMappedExeConfiguration(configFile,
            ConfigurationUserLevel.None);
    
        // Display the configuration file sections.
        ConfigurationSectionCollection sections = config.Sections;
    
        Console.WriteLine();
        Console.WriteLine("Sections in machine.config:");
    
        // Loop to get the sections machine.config.
        foreach (ConfigurationSection section in sections)
        {
            string name = section.SectionInformation.Name;
            Console.WriteLine("Name: {0}", name);
        }
    
    }
