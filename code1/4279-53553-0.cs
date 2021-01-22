    static void GetMappedExeConfigurationSections()
    {
        // Get the machine.config file.
        ExeConfigurationFileMap fileMap =
            new ExeConfigurationFileMap();
        // You may want to map to your own exe.comfig file here.
        fileMap.ExeConfigFilename = 
            @"C:\test\ConfigurationManager.exe.config";
        System.Configuration.Configuration config =
            ConfigurationManager.OpenMappedExeConfiguration(fileMap, 
            ConfigurationUserLevel.None);
    
        // Loop to get the sections. Display basic information.
        Console.WriteLine("Name, Allow Definition");
        int i = 0;
        foreach (ConfigurationSection section in config.Sections)
        {
            Console.WriteLine(
                section.SectionInformation.Name + "\t" +
            section.SectionInformation.AllowExeDefinition);
            i += 1;
    
        }
        Console.WriteLine("[Total number of sections: {0]", i);
    
        // Display machine.config path.
        Console.WriteLine("[File path: {0]", config.FilePath);
    }
