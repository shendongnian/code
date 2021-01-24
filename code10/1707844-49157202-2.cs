	public class ConsoleRegistry : Registry
	{
		public ConsoleRegistry()
		{
			Scan(_ =>
			{
				_.TheCallingAssembly();
				_.With(new SingletonConvention<IFileService>());
				_.WithDefaultConventions();
			});
		}
	}
    internal class SingletonConvention<TPluginFamily> : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || !type.CanBeCreated() || !type.AllInterfaces().Contains(typeof(TPluginFamily))) return;
            registry.For(typeof(TPluginFamily)).Singleton().Use(type);
        }
    }
