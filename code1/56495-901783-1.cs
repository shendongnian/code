    private void CreateContainer()
    {
        ExeConfigurationFileMap map = new ExeConfigurationFileMap();
        map.ExeConfigFilename = // path to config file
        // get section from config code goes here
        IUnityContainer container = new UnityContainer();
        container.AddNewExtension<UnityExtensionWithTypeTracking>();
        section.Containers.Default.Configure(container);
        
    }
    
