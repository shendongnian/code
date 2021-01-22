    public class PluginSample : MarshalByRefObject, IPlugin
    {
      
       public overrides object InitializeLifetimeService()
       {
           return null; //Return null to infinite object remote life.
       }
      //...implementation
    }
