    /* ----- Startup.cs ----- */
    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddScoped<IxxxService, xxxBusinessService>();
    }
    /* ----- UI Layer ----- */
    public xxxController(IxxxService xxxBusinessService)
    {
       this.xxxBusinessService = xxxBusinessService;
    }
    /* ----- BUSINESS LAYER ----- */
    /*
    UI/controller knows Business service and IConfiguration objects, and default 
    injector automatically creates/passes configuration object via ctor to Business layer.
    */
    public xxxService(IConfiguration configuration)
    {
    	this.xxxRepository = new xxxRepository(configuration);
    }
    /* ----- DATA LAYER ----- */
    public class xxxRepository: BaseRepository, IxxxRepository
    {
    	public xxxRepository(IConfiguration configuration)
    		: base(configuration)
    	{
    
    	}
    }		
    		
    public class BaseRepository{
    	
    	protected xxxDbContext context;
    
    	public BaseRepository(IConfiguration configuration)
    	{	
    		var optionsBuilder = new DbContextOptionsBuilder<xxxDbContext>();
    
    		optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionString")["DefaultConnection"]);
    
    		this.context = new xxxDbContext(optionsBuilder.Options);
    	}
    }
