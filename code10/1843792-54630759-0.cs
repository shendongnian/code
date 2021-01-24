using System;
using System.ServiceProcess;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;
namespace SFLSolidWorkAPI
{
    public partial class DemoService : ServiceBase
    {
        public DemoService ()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8069");
            
            config.Routes.MapHttpRoute(
               name: "API",
               routeTemplate: "{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            config.EnableCors(new EnableCorsAttribute("*", headers: "*", methods: "*"));
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
        }
        protected override void OnStop()
        {
        }
    }
    
}
