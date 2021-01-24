[TestMethod]
public void ValidateDependencies()
{
	// This is only necessary if you have reliance on the configuration.
	// Make sure that your appsettings.json "Build Action" is "Content" and the "Copy to Output Directory" is "Copy if newer" or "Copy always"
	var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
	var svcCollection = new ServiceCollection();
	// We've moved our dependencies to an extension method
	svcCollection.RegisterServices(config);
	var controllers = typeof(CustomerController).Assembly.ExportedTypes
		.Where(x => !x.IsAbstract && typeof(ControllerBase).IsAssignableFrom(x)).ToList();
	// By default, the controllers are not loaded so this is necessary
	controllers.ForEach(c => svcCollection.AddTransient(c));
	var serviceProvider = svcCollection.BuildServiceProvider();
	var errors = new Dictionary<Type, Exception>();
	foreach (Type controllerType in controllers)
	{
		try
		{
			serviceProvider.GetRequiredService(controllerType);
		}
		catch (Exception ex)
		{
			errors.Add(controllerType, ex);
		}
	}
	if (errors.Any())
		Assert.Fail(string.Join("\n",
			errors.Select(x => $"Failed to resolve controller {x.Key.Name} due to {x.Value}")));
}
