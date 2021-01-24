    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Owin;
    
    namespace OpenIddictOwinDemo
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseBuilder(ConfigureServices(), Configure);
            }
    
            IServiceProvider ConfigureServices()
            {
                var services = new ServiceCollection();
    
                // In a real ASP.NET Core application, these services are
                // registered by the hosting stack. Since this application
                // is actually an OWIN app, they must be registered manually.
                var listener = new DiagnosticListener("Microsoft.AspNetCore");
                services.AddSingleton<DiagnosticListener>(listener);
                services.AddSingleton<DiagnosticSource>(listener);
                services.AddSingleton<IHostingEnvironment, HostingEnvironment>();
    
                services.AddDbContext<DbContext>(options =>
                {
                    options.UseInMemoryDatabase("db");
                });
    
                services.AddOpenIddict()
                    .AddCore(options =>
                    {
                        options.UseEntityFrameworkCore()
                            .UseDbContext<DbContext>();
                    })
    
                    .AddServer(options =>
                    {
                        options.AcceptAnonymousClients();
                        options.AllowPasswordFlow();
                        options.EnableTokenEndpoint("/connect/token");
                        options.DisableHttpsRequirement();
    
                        options.UseCustomTokenEndpoint();
                    });
    
                return services.BuildServiceProvider(validateScopes: true);
            }
    
            void Configure(IApplicationBuilder app)
            {
                // This inline middleware is required to be able to use scoped services.
                // In a real ASP.NET Core application, this is done for you by a special
                // middleware automatically injected by the default hosting components.
                app.Use(next => async context =>
                {
                    var provider = context.RequestServices;
                    using (var scope = provider.CreateScope())
                    {
                        try
                        {
                            context.RequestServices = scope.ServiceProvider;
    
                            await next(context);
                        }
    
                        finally
                        {
                            context.RequestServices = provider;
                        }
                    }
                });
    
                app.UseDeveloperExceptionPage();
    
                app.UseAuthentication();
            }
        }
    }
