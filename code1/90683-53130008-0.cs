    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace ContentNegotiation
    {
        public class Program
        {
            public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        }
    
        public class MyXmlSerializerOutputFormatter : XmlSerializerOutputFormatter
        {
            protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
            {
                // TODO: add me only if controller has some kind of custom attribute with XSLT file name
                xmlWriter.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"template.xsl\"");
                base.Serialize(xmlSerializer, xmlWriter, value);
            }
        }
    
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(options =>
                {
                    options.RespectBrowserAcceptHeader = true; // default is false
                    // options.OutputFormatters.Add(new XmlSerializerOutputFormatter()); // not enough
                    options.OutputFormatters.Add(new MyXmlSerializerOutputFormatter());
                })
                // .AddXmlSerializerFormatters() // does not added by default, but not enough
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseStaticFiles();
                app.UseMvc();
            }
        }
    
        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    
        [ApiController]
        public class DemoController : ControllerBase
        {
            // curl -k -i -s -H 'Accept: text/xml' http://localhost:5000/posts
            // curl -k -i -s -H 'Accept: application/json' http://localhost:5000/posts
            [HttpGet]
            [Route(nameof(Posts))]
            public IEnumerable<Post> Posts() => new[] {
                new Post {
                    Id = 1,
                    Title = "Hello World",
                    Body = "Lorem ipsum dot color"
                },
                new Post {
                    Id = 2,
                    Title = "Post 2",
                    Body = "Lorem ipsum dot color"
                }
            };
        }
    }
