    public class BasicAuthFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
            {
                { "Basic", new string[] { } }
            };
            swaggerDoc.Security = new[] { securityRequirements };
        }
    }
    //In the Startup class...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            c.AddSecurityDefinition("Basic", new BasicAuthScheme { Description = "Basic authentication" });
                c.DocumentFilter<BasicAuthFilter>();
        });
        services.AddMvc();
    }
