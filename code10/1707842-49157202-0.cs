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
