	services.AddSimpleInjector(container, options =>
	{
		// AddAspNetCore() wraps web requests in a Simple Injector scope.
		options.AddAspNetCore()
			// Ensure activation of a specific framework type to be created by
			// Simple Injector instead of the built-in configuration system.
			.AddControllerActivation()
			.AddViewComponentActivation()
			.AddPageModelActivation()
			.AddTagHelperActivation();
	});
