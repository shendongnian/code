        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    using System.Web.Routing;
    namespace a2zcrackworld
    {
        public class Global : System.Web.HttpApplication
        {
            void RegisterRoutes(RouteCollection routes)
            {
                routes.MapPageRoute("Home", "software", "~/software.aspx");
                routes.MapPageRoute("Downloadsoft", "download/soft/{SoftwareID}", "~/downloadsoftware.aspx");
                routes.MapPageRoute("Opratingsystem", "operating", "~/OpratingSystem.aspx");
     }
            void RegisterRoutessoftware(RouteCollection routes)
            {
                
    
            }
            protected void Application_Start(object sender, EventArgs e)
            {
                RegisterRoutes(RouteTable.Routes);
                RegisterRoutessoftware(RouteTable.Routes);
            }
    }
