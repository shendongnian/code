    public class CustomModule : IHttpModule 
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_BeginRequest);
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            // you can use the context.Request here to send it to the database or a log file
        }
    }
