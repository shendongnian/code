    public class IdentifiedScope
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
    // Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IdentifiedScope>();
    }
    // Controller
    public MyController(IdentifiedScope identifiedScope)
    {
        this.identifiedScope = identifiedScope;
    }
    // Usage in an ActionFilter
    public override async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                      ActionExecutionDelegate next)
    {
        var identifiedScope = 
               context.HttpContext.RequestServices.GetService<IdentifiedScope>();
    }
