    private static void ConfigureDefaultServices(IServiceCollection services, string customApplicationBasePath)
    {
    	string applicationName;
    	IFileProvider fileProvider;
    	if (!string.IsNullOrEmpty(customApplicationBasePath))
    	{
    		applicationName = Path.GetFileName(customApplicationBasePath);
    		fileProvider = new PhysicalFileProvider(customApplicationBasePath);
    	}
    	else
    	{
    		applicationName = Assembly.GetEntryAssembly().GetName().Name;
    		fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    	}
    
    	services.AddSingleton<IHostingEnvironment>(new HostingEnvironment
    	{
    		ApplicationName = applicationName,
    		WebRootFileProvider = fileProvider,
    	});
    
    	var diagnosticSource = new DiagnosticListener("Microsoft.AspNetCore");
    	services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
    	services.AddSingleton<DiagnosticSource>(diagnosticSource);
    	services.AddLogging();
    	services.AddTransient<RazorViewToStringRenderer>();
    	services.Configure<RazorViewEngineOptions>(options =>
    	{
    		options.ViewLocationFormats.Add("/Views/{0}.cshtml");
    
    		options.FileProviders.Clear();
    		options.FileProviders.Add(fileProvider);
    	});
    	services.AddMvc();
    }
