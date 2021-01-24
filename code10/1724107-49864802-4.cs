    public class Startup {
        //...
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            
            //...
            
            services.ConfigureCustomOutput();
            
            //...
        }
    }
