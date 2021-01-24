    using System.Collections.Generic;
    using dbzBest.Models;
    using Microsoft.AspNetCore.Mvc;
    
    namespace zpmAPI.Controllers
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        [Consumes("application/json")]
        public class PropertyController : ControllerBase
        {
            [HttpPost]
            public List<PropertyTile> Search(PropertySearch s)
            {
                try
                {
                    List<PropertyTile> tiles = new List<PropertyTile>();
                    dbzBest.Data.Properties db = new dbzBest.Data.Properties();
                    tiles = db.Search(s);
                    return tiles;
                }
                catch (System.Exception ex)
                {
                    PropertyTile e = new PropertyTile();
                    e.Description = ex.Message;
                    List<PropertyTile> error = new List<PropertyTile>();
                    error.Add(e);
                    return error;
                }
            }
        }
    }
    
    
        using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace zpmAPI
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
                services.AddCors();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
    
                app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                app.UseHttpsRedirection();
                app.UseMvc();
            }
        }
    }
