    public class WsdlModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            HttpContext context = app.Context;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string url = request.Url.AbsoluteUri.ToLower();
            if (url.Contains("wsdl"))
            {
                response.WriteFile(context.Server.MapPath("wsdl/1.0/Service.wsdl"));
                response.End();
            }
        }
    }
