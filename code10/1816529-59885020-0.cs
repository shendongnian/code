GraphQL.Server.Authorization.AspNetCore
In Startup.cs add the following in ConfigureServices. Make sure to add these using statements:
    using GraphQL.Validation;
    using GraphQL.Server.Authorization.AspNetCore;
    public void ConfigureServices(IServiceCollection services)
    {
        //... other code
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services
            .AddTransient<IValidationRule, AuthorizationValidationRule>()
            .AddAuthorization(options =>
            {
                options.AddPolicy("LoggedIn", p => p.RequireAuthenticatedUser());
            });
        //... other code
    }
Now you'll be able to use `AuthorizeWith()` at the resolver level to protect the field. Example:
    public class MyQuery : ObjectGraphType
    {
        public MyQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAllAsync() 
            ).AuthorizeWith("LoggedIn");
        }
    }
You can also protect all queries by adding `this.AuthorizeWith()` to the top of the Query constructor like this:
     public class MyQuery : ObjectGraphType
     {
         public MyQuery(ProductRepository productRepository)
         {
             this.AuthorizeWith("LoggedIn");
             Field<ListGraphType<ProductType>>(
                 "products",
                 resolve: context => productRepository.GetAllAsync() 
             );
         }
     }
With that, any unauthenticated access to your GraphQL endpoint will be rejected.
Now in terms of logging someone in, there are many ways to do that. Here's a quick Cookie based authentication example:
Configure cookie based authentication in Startup.cs' ConfigureServices:
        
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
            {
                o.Cookie.Name = "graph-auth";
            });
Use mutation to log someone in:
    public class Session
    {
        public bool IsLoggedIn { get; set; }
    }
    public class SessionType : ObjectGraphType<Session>
    {
        public SessionType()
        {
            Field(t => t.IsLoggedIn);
        }
    }
    public class MyMutation : ObjectGraphType
    {
        public MyMutation(IHttpContextAccessor contextAccessor)
        {
            FieldAsync<SessionType>(
                "sessions",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }),
                resolve: async context =>
                {
                    string password = context.GetArgument<string>("password");
                    // NEVER DO THIS...for illustration purpose only! Use a proper credential management system instead. :-)
                    if (password != "123")
                        return new Session { IsLoggedIn = false };
                    var principal = new ClaimsPrincipal(new ClaimsIdentity("Cookie"));
                    await contextAccessor.HttpContext.SignInAsync(principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMonths(6),
                        IsPersistent = true
                    });
                    return new Session { IsLoggedIn = true };
                });
        }
    }
