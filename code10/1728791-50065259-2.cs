I figured one way to inject into the construtor of PageModel using Simple Injector:
    
    public class SimpleInjectorPageModelActivatorProvider : IPageModelActivatorProvider
    {
        private Container Container { get; }
        public SimpleInjectorPageModelActivatorProvider(Container c) => Container = c;
        public Func<PageContext, object> CreateActivator(CompiledPageActionDescriptor d) =>
            _ => Container.GetInstance(d.ModelTypeInfo.AsType());
        public Action<PageContext, object> CreateReleaser(CompiledPageActionDescriptor d) =>
            null;
    }
