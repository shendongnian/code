    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    
    namespace samp
    {
        public class MailServer
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public bool UseSSL { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string FromAddress { get; set; }
            public MailServer()
            {
            }
        }
    
        public interface IScheduledTask
        {
            void MonitorCloudHosts();
        }
    
        public class ScheduledTask : IScheduledTask
        {
            private readonly IServiceProvider _ServiceProvider;
            private readonly MailServer _mailServer;
    
            // note here you ask to the injector for IServiceProvider
            public ScheduledTask(IServiceProvider serviceProvider, IOptions<MailServer> optionsAccessor)
            {
                _ServiceProvider = serviceProvider;
                _mailServer = optionsAccessor.Value;
            }
    
            public void MonitorCloudHosts()
            {
                // Do some stuff
                var xyz = _mailServer.Host;
            }
        }
    
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                services.Configure<MailServer>(Configuration.GetSection("MailServer"));
                services.AddSingleton<IScheduledTask, ScheduledTask>();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }
    
                app.UseHttpsRedirection();
                app.UseMvc();
            }
        }
    }
