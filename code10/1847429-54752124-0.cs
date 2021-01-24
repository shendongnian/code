public class Startup
{
	public Startup(IConfiguration configuration, IHostingEnvironment environment)
	{
		Configuration = configuration;
		HostingEnvironment = environment;
	}
	public IConfiguration Configuration { get; }
	public IHostingEnvironment HostingEnvironment { get; }
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddLocalization(options => options.ResourcesPath = "Resources");
		
		services.AddMvc()
			.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
			.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
			.AddDataAnnotationsLocalization();
		services.Configure<RequestLocalizationOptions>(options =>
		{
			var supportedCultures = new[]
			{
				new CultureInfo("ru"),
				new CultureInfo("uk")
			};
			options.DefaultRequestCulture = new RequestCulture("uk");
			options.SupportedCultures = supportedCultures;
			options.SupportedUICultures = supportedCultures;
			options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
		});
	}
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		var localizationOptions= app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
		app.UseRequestLocalization(localizationOptions);
	}
}
