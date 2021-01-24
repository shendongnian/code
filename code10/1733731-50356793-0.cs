    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BPT.PC.IdentityServer.Data;
    using BPT.PC.IdentityServer.IdentityStore;
    using BPT.PC.IdentityServer.Models;
    using BPT.PC.IdentityServer.Web.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    
    namespace BPT.PC.IdentityServer.Web
    {
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
                services.AddIdentity<User, Role>()
                    .AddUserStore<UserStore>()
                    .AddRoleStore<RoleStore>()
                    .AddDefaultTokenProviders();
    
                services.AddMemoryCache();
                services.AddDistributedMemoryCache();
                services.AddDbContext<IdentityServerDb>
                    (options => options.UseSqlServer(Configuration.GetConnectionString("IdentityServerDb")));
    
                services
                    .AddMvc();
                services
                    .AddAuthentication(auth =>
                    {
                        auth.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        auth.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        auth.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    })
                    .AddCookie()
                    .AddOpenIdConnect("AzureAD", "AzureAD", options =>
                    {
                        Configuration.GetSection("AzureAD").Bind(options); ;
                        options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                        options.RemoteAuthenticationTimeout = TimeSpan.FromSeconds(120);
                        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.RequireHttpsMetadata = false;
                        options.SaveTokens = true;
                    });
                
                services.AddSingleton(Configuration.GetSection("OpenIdConnectProviderConfiguration").Get<OpenIdConnectProviderConfiguration>());
                
            }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseBrowserLink();
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
                app.UseAuthentication();
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Account}/{action=Login}/{id?}");
                });
            }
        }
    }
