        public class DependencyInjectionPlugin
        {
            public IContainer Container { get; set; }
            public T Resolve<T>()
            {
                return Container.Resolve<T>();
            }
        }
        [PluginProviderType(typeof(DependencyInjectionPluginProvider))]
        public class DependencyInjectionPluginConfiguration : IPluginConfiguration
        {
            public void WriteBinary(IBinaryRawWriter writer)
            {
                // No-op
            }
            public int? PluginConfigurationClosureFactoryId { get; } = null; // No Java part
        }
        public class DependencyInjectionPluginProvider : IPluginProvider<DependencyInjectionPluginConfiguration>
        {
            public string Name { get; } = "DependencyInjection";
            public string Copyright { get; } = "MIT";
            protected DependencyInjectionPlugin DependencyInjectionPlugin { get; set; }
            
            public T GetPlugin<T>() where T : class
            {
                return DependencyInjectionPlugin as T;
            }
            public void Start(IPluginContext<DependencyInjectionPluginConfiguration> context)
            {
                DependencyInjectionPlugin = new DependencyInjectionPlugin();
            }
            public void Stop(bool cancel)
            {
                
            }
            public void OnIgniteStart()
            {
                
            }
            public void OnIgniteStop(bool cancel)
            {
                
            }
        }
