    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.FileProviders;
    using Owin;
    
    namespace OpenIddictOwinDemo
    {
        using AddMiddleware = Action<Func<
            Func<IDictionary<string, object>, Task>,
            Func<IDictionary<string, object>, Task>
        >>;
        using AppFunc = Func<IDictionary<string, object>, Task>;
    
        public static class KatanaExtensions
        {
            public static IAppBuilder UseBuilder(this IAppBuilder app,
                IServiceProvider provider, Action<IApplicationBuilder> configuration)
            {
                if (app == null)
                {
                    throw new ArgumentNullException(nameof(app));
                }
    
                if (provider == null)
                {
                    throw new ArgumentNullException(nameof(provider));
                }
    
                if (configuration == null)
                {
                    throw new ArgumentNullException(nameof(configuration));
                }
    
                AddMiddleware add = middleware =>
                {
                    app.Use(new Func<AppFunc, AppFunc>(next => middleware(next)));
                };
    
                add.UseBuilder(configuration, provider);
    
                return app;
            }
        }
    
        public class HostingEnvironment : IHostingEnvironment
        {
            public string EnvironmentName { get; set; }
            public string ApplicationName { get; set; }
            public string WebRootPath { get; set; }
            public IFileProvider WebRootFileProvider { get; set; }
            public string ContentRootPath { get; set; }
            public IFileProvider ContentRootFileProvider { get; set; }
        }
    }
