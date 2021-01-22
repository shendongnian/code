    using System;
    using System.Net;
    using System.Web;
    
    namespace HttpLibArticleSite
    {
        public class GuardDogModule : IHttpModule
        {
            #region IHttpModule Members
    
            public void Init(HttpApplication context)
            {
                context.BeginRequest += BeginRequest;
            }
    
            public void Dispose()
            {
                //noop
            }
    
            #endregion
    
            private static void BeginRequest(object sender, EventArgs e)
            {
                HttpContext ctx = (HttpContext) sender;
    
                if (ctx.Request.Url is not guarded) return;
                if (ctx.Request.Headers["take your pick"] != what
                you want)
                {
                    ctx.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                    ctx.Response.End();
                }
            }
        }
    }
