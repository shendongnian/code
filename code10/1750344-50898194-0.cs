    public class Startup
    {
    		public void ConfigureServices(IServiceCollection services)
    		{
    			services.AddMyScoped();
    			services.AddMyTransient();
    		}
    }
