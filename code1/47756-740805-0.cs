    namespace PluginInterface
    {
        public interface IPlugin
        {
            string Name { get; }
            string Run(string input);
        }
    }
