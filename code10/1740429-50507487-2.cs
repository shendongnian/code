    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Microsoft.Net.Http.Headers; // required
    namespace WebApplication1
    {
        public class Startup
        {
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                var durationInSeconds = (int) TimeSpan.FromDays(1).TotalSeconds;
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = context =>
                    {
                        context.Context.Response.Headers[HeaderNames.CacheControl] =
                            $"public,max-age={durationInSeconds}";
                    }
                });
                app.UseMvc();
            }
        }
    }
