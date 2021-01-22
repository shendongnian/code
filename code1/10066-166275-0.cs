    static void Main(string[] args)
    {
        if (args.Length != 0)
        {
            Console.Error.WriteLine("Usage : Program.exe <configFileName>"); // App.Config
        }
        EncryptSection(args[0], "connectionStrings", "DataProtectionConfigurationProvider");
    }
    private static void EncryptSection(string configurationFile, string sectionName, string providerName)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(configurationFile);
        ConfigurationSection section = config.GetSection(sectionName);
        if (section != null && !section.SectionInformation.IsProtected)
        {
            section.SectionInformation.ProtectSection(providerName);
            config.Save();
        }
    }
