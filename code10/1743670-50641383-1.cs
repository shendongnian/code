    class SimpleInjectorWebFormsServiceActivator : IServiceProvider
    {
        private readonly Container container;
        private readonly Assembly applicationAssembly;
        public SimpleInjectorWebFormsServiceActivator(
            Container container, Assembly applicationAssembly)
        {
            this.container = container;
            this.applicationAssembly = applicationAssembly;
        }
        public object GetService(Type serviceType) =>
            this.IsApplicationType(serviceType)
            ? _container.GetInstance(serviceType)
            : CreateNonUserTypes(serviceType);
        private bool IsApplicationType(Type serviceType) =>
            serviceType.Assembly == this.applicationAssembly 
            || serviceType.BaseType.Assembly == this.applicationAssembly;
        private static object CreateNonUserTypes(Type serviceType) =>
            Activator.CreateInstance(
                serviceType,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public 
                | BindingFlags.CreateInstance,
                null, null, null);
    }
