    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(("MyApp"));
                        b.EnableRetryOnFailure();
                    })
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.IncludeIgnoredWarning)));
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async ctx =>
                        {
                            var clientId = ctx.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                            var db = ctx.HttpContext.RequestServices.GetRequiredService<DataContext>();
                            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(clientId));
                            if (user != null)
                            {
                                var userRole = user.UserRole;
                                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Role, userRole.ToString())
                                };
                                var appIdentity = new ClaimsIdentity(claims);
                                ctx.Principal.AddIdentity(appIdentity);
                            }
                        }
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }).AddCookie();
            //...
        }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });
            app.UseHangfireServer();
            //...
        }
    }
    public class HangfireAuthorizationFilter : ControllerBase, IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            try
            {
                var httpContext = context.GetHttpContext();
                var userRole = httpContext.Request.Cookies["UserRole"];
                return userRole == UserRole.Admin.ToString();
            }
            catch
            {
                return false;
            }
        }
    }
