    // Startup.cs
    public partial class Startup {
    	public void ConfigureServices(IServiceCollection services) {
    		ConfigureScopedServices(services);
    		ConfigureTransientServices(services);
    	}
    }
    
    // ScopedServices.cs
    public partial class Startup {
    	private static void ConfigureScopedServices(IServiceCollection services) {
    		Console.WriteLine("Scoped");
    	}
    }
    
    // TransientServices.cs
    public partial class Startup {
    	private static void ConfigureTransientServices(IServiceCollection services) {
    		Console.WriteLine("Transient");
    	}
    }
