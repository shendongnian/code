        public interface IPlugin {
            string Name { get; }
            string Description { get; }
            string Author { get; }
            string Version { get; }
                
            IPluginHost Host { get; set; }
            
            void Init();
            void Unload();
            
            IDictionary<int, string> GetOptions();
            void ExecuteOption(int option);
	}
        
        public interface IPluginHost {
            IDictionary<string, object> Variables { get; }
            void Register(IPlugin plugin);
         }
