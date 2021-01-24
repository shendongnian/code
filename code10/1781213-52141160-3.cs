    public class InjectConfiguration : IExtensionConfigProvider
    {
        private IServiceProvider _serviceProvider;
        
        public InjectConfiguration(IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;
        }
   
        public void Initialize(ExtensionConfigContext context)
        {         
            context
                .AddBindingRule<InjectAttribute>()
                .BindToInput<dynamic>(i => _serviceProvider.GetRequiredService(i.Type));
        }
    }
