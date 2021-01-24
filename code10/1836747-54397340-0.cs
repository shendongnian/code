    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
                services.AddDbContext<MyContext>((serviceProvider, options) =>
                {
                    var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                    var connection = GetConnection(httpContext);
                    options.UseNpgsql(connection);
                });
    
    private string GetConnection(HttpContext httpContext)
            {
                var UserName = httpContext?.User?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
    		     // Here extract ConnectionString from "MyClientContext"'s DB
            }
