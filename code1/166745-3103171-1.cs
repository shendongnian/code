    public interface IPlugin {
               // Many, many happy API things like this...
               void SetupOptions(Hashtable options);
               // (examples elided)
    
               XmlDocument RunPlugin();
    }
    
    //
    // And another interface extending the IPlugin that defines the update version
    //
    
    public interface IUpdaterPlugin : IPlugin {
               XmlDocument RunPlugin(Updater u);
    
    }
