	public static bool IsAssemblyConfiguration(Assembly assembly, string configuration)
	{
		var attributes = assembly.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
		if (attributes.Length == 1)
		{
			var assemblyConfiguration = attributes[0] as AssemblyConfigurationAttribute;
			if (assemblyConfiguration != null)
			{
				return assemblyConfiguration.Configuration.Equals(configuration, StringComparison.InvariantCultureIgnoreCase);
			}
		}
		return true;
	}
