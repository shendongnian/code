    // interface
    public interface IAppPrincipal
    {
        string Name { get; }
    }
    
    // concrete class
    public class AppPrincipal : IAppPrincipal
    {
        public AppPrincipal(string name)
        {
            Name = name;
        }
    
        public string Name { get; }
    }
    // db context
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IAppPrincipal principal = null)
        {
            Principal = principal;
        }
        public IAppPrincipal Principal { get; }
        public override int SaveChanges()
        {
            var audit = new Audit();
            audit.CreatedBy = Principal?.Name;
            ...
        }
    }
    // service registration in API or MVC app
    services.AddScoped<IAppPrincipal>(provider => 
    {
        var user = provider.GetService<IHttpContextAccessor>()?.HttpContext?.User;
        return new AppPrincipal(user?.Identity?.Name);
    });
