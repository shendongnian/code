    interface IHost {
         string[] ReadConfiguration(string fileName);
    }
    interface IPlugin {
         void Initialize(IHost host);
    }
    class MyPlugin : IPlugin {
         public void Initialize(IHost host) {
             host.ReadConfiguration("myplygin.config");
         }
    }
