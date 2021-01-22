    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace MvcApplication2
    {
        /// <summary>
        /// Summary description for $codebehindclassname$
        /// </summary>
        public class Environment : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/javascript";
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(600));
                context.Response.Write(String.Format("Environment = {{ RootPath:\"{0}\" }};", context.Request.ApplicationPath)); // set any application info you need here
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
