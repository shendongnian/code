     public class Startup
     {
         public Startup(IConfiguration configuration)
         {
             Configuration = configuration;
         }
 
         public IConfiguration Configuration { get; }
         public static HttpMessageHandler Handler { get; set; }
 
         public void ConfigureServices(IServiceCollection services)
         {
             services.AddMvc();
 
             services.AddIdentityServer()
                 .AddDeveloperSigningCredential()
                 .AddInMemoryIdentityResources(Config.IdentityResources)
                 .AddInMemoryClients(Config.Clients)
                 .AddInMemoryApiResources(Config.Apis)
                 .AddTestUsers(TestUsers.Users);
            services.AddAuthentication()
               .AddJwtBearer(jwt =>
               {
                   jwt.BackchannelHttpHandler = Handler;
                   jwt.Authority = "http://localhost/";
                   jwt.RequireHttpsMetadata = false;
                   jwt.Audience = "api1";
               });
                .AddJwtBearer(jwt =>
                {
                    // defaults as they were
                    jwt.Authority = "http://localhost:5000/";
                    jwt.RequireHttpsMetadata = false;
                    jwt.Audience = "api1";
                    // if static handler is null don't change anything, otherwise assume integration test.
                    if(Handler == null)
                    {
                        jwt.BackchannelHttpHandler = Handler;
                        jwt.Authority = "http://localhost/";
                    }
                });
        }
