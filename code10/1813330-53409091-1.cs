	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<Service>();
            // TODO: other init staffs
		}
	}
