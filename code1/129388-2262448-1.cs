    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
    //section.SectionInformation.UnprotectSection();
    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
    config.Save();
