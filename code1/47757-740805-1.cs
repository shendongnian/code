    namespace PluginX
    {
        using PluginInterface;
    
        public class Plugin : IPlugin
        {
            public string Name
            {
                get { return "Plugin X"; }
            }
    
            public string Run(string input)
            {
                return input;
            }
        }
    }
