    //folder position 
    create folders to house our models, controllers, data, and migrations. It’s also recommended that you create a folder for APIs called Areas
    Now that we have the folders set up, let’s start by creating our UserStore. We’ll need this in order to authenticate our users and generate tokens. One of the best ways to do this is to create a User class that extends from IdentityUser.
    //Add models for identity server user
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace TokenAuthASPCore.Models
    {
        public class ApplicationUser : IdentityUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
    Also, let’s create a Todo class for testing our REST API later on.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace TokenAuthASPCore.Models
    {
        public class Todo
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public bool Finished { get; set; }
        }
    }
    Setting up our Database
    In order to be able to use both of these, we must first connect to a database. I’ll be using MS SQL-Server.
    Add a connection string to you appsettings.json file that specifies the location of the database that you want to interact with.
    "ConnectionStrings": {
        "TestConnection": "Data Source=DESKTOP-GIIMG7O\\JAMES;Initial Catalog=IdentityBlog;Integrated Security=True"
      }
    Then go to your Startup.cs file and add your configuration for your database connection.
    services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
    IdentityServer 4 Configuration
    The next step is to configure IdentityServer4. IdentityServer4 is a framework that allows for us to add OIDC authentication and authorization to our APS.NET Core application. It allows for the generation of JWT tokens and supports many of the Oauth 2 flows. We’ll be using the ResourceOwnerPassword flow because, in later tutorials, we’ll be authentication with both a React and Angular app as well as a Xamarin application.
    We’ll start off by creating a Config.cs file. This will hold most of our configuration for IdentityServer 4.
    using IdentityServer4;
    using IdentityServer4.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace TokenAuthASPCore
    {
        public class Config
        {
            public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile(),
                };
            }
            public static IEnumerable<ApiResource> GetApiResources()
            {
                return new List<ApiResource>
                {
                    new ApiResource("api1", "My API")
                };
            }
            public static IEnumerable<Client> GetClients()
            {
                // client credentials client
                return new List<Client>
                {
                    
                    // resource owner password grant client
                    new Client
                    {
                        ClientId = "ro.angular",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            IdentityServerConstants.StandardScopes.Address,
                            "api1"
                        }
                    }
                };
            }
        }
    }
    IdentityResources represent what information we can get from our Identity Store, our API Resources represent the API information we can access and the Clients represent what clients are allowed to authenticate with our API.
    If we jump back to our Startup.cs file, we can now register IdentityServer4 as a service. This is configured in your ConfigureServices method.
    services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryPersistedGrants()
                    .AddInMemoryIdentityResources(Config.GetIdentityResources())
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients())
                    .AddAspNetIdentity<ApplicationUser>();
                services.AddMvc();
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                    {
                        // base-address of your identityserver
                        options.Authority = "http://localhost:52718/";
                        // name of the API resource
                        options.Audience = "api1";
                        options.RequireHttpsMetadata = false;
                    });
    		//We’ll also add routing and IdentityServer to our HTTP pipeline.
    		// Inside of the Configure method add
    		app.UseIdentityServer();
                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
    User Registration
    Now that we have Identity Server set up, we’ll have to create a way for our users to sign-up. Let’s start off by creating a view model for user registrations.  Then we’ll create an AccountController for user signup.
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    namespace TokenAuthASPCore.Models.AccountViewModels
    {
        public class RegisterViewModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2}, at max {1} characters long and unique.", MinimumLength = 2)]
            [Display(Name = "Username")]
            public string UserName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TokenAuthASPCore.Areas.v1.Models.UserViewModels;
    using TokenAuthASPCore.Models;
    using TokenAuthASPCore.Models.AccountViewModels;
    namespace TokenAuthASPCore.Areas.Controllers
    {
        [Area("v1")]
        public class AccountController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            public AccountController(
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager
                )
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            [HttpPost]
            public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new ApplicationUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                string role = "Basic User";
                if (result.Succeeded)
                {
                    if (await _roleManager.FindByNameAsync(role) == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                    await _userManager.AddToRoleAsync(user, role);
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("firstName", user.FirstName));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("lastName", user.LastName));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
                    await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));
                    return Ok(new ProfileViewModel(user));
                }
                return BadRequest(result.Errors);
            }
        }
    }
    Inside of the controller, we have a register method that takes in the data from a validated ViewModel, creates the user with a basic role, then adds claims to that user.
    We’ll also create a ProfileViewModel creating a custom output of user data.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TokenAuthASPCore.Models;
    namespace TokenAuthASPCore.Areas.Models.UserViewModels
    {
        public class ProfileViewModel
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public ProfileViewModel()
            {
            }
            public ProfileViewModel(ApplicationUser user)
            {
                Id = user.Id;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
            }
            public static IEnumerable<ProfileViewModel> GetUserProfiles(IEnumerable<ApplicationUser> users)
            {
                var profiles = new List<ProfileViewModel> { };
                foreach (ApplicationUser user in users)
                {
                    profiles.Add(new ProfileViewModel(user));
                }
                return profiles;
            }
        }
    }
    Adding Claims To the JWT
    In order the add Claims to the JWT token, you’re going to have to create a class that implements the IdentityServer4.Services.IProfileService interface. This is used to determine the profile data that is placed into the JWT.
    public class IdentityClaimsProfileService : IProfileService
    {
    }Copy
    Now that you have the class, you’ll have the implement both GetProfileDataAsync() and IsActiveAsync(). You’ll have to define a ClaimsFactory as well as the UserManager for getting your user information.
    	private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
            private readonly UserManager<ApplicationUser> _userManager;
            public IdentityClaimsProfileService(UserManager<ApplicationUser> userManager, 	IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
            {
                _userManager = userManager;
                _claimsFactory = claimsFactory;
            }
    Once this is done, use the GetProfileDataAsync method to populate your JWT with the desired User information.
    	public async Task GetProfileDataAsync(ProfileDataRequestContext context)
            {
                var sub = context.Subject.GetSubjectId();
                var user = await _userManager.FindByIdAsync(sub);
                var principal = await _claimsFactory.CreateAsync(user);
                var roles = await _userManager.GetRolesAsync(user);
                var claims = principal.Claims.ToList();
                claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
                claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
                claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
                foreach(string role in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, role));
                }
                
                context.IssuedClaims = claims;
            }
    As you see here, I place the user’s email and firstname in the token. You can decode the JWT and use this inside of a Javascript or Native application to display the user info without having to do a constant fetch of user information.
    Next, we’ll create an implementation of IsActiveAsync. This will check whether the user is valid in your database.
    	public async Task IsActiveAsync(IsActiveContext context)
            {
                var sub = context.Subject.GetSubjectId();
                var user = await _userManager.FindByIdAsync(sub);
                context.IsActive = user != null;
            }
    Now that this is done, now you have to configure your application to use your custom implementation of IProfileService.
    Inside of you Statup.cs file, you must use Dependency Injection to specify this implementation.
    services.AddTransient<IProfileService, IdentityClaimsProfileService>();
    //Bellow is the Startup class
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryPersistedGrants()
                    .AddInMemoryIdentityResources(Config.GetIdentityResources())
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients())
                    .AddAspNetIdentity<ApplicationUser>();
                services.AddMvc();
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                    {
                        // base-address of your identityserver
                        options.Authority = "http://localhost:52718/";
                        // name of the API resource
                        options.Audience = "api1";
                        options.RequireHttpsMetadata = false;
                    });
    	services.AddTransient<IProfileService, IdentityClaimsProfileService>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseIdentityServer();
                app.UseAuthentication();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
    //In main method of the proghrame.cs call the startup
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
