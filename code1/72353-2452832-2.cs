    public class TestModule :IHttpModule
        {
            #region IHttpModule Members
    
            public void Dispose()
            {
                
            }
    
            public void Init(HttpApplication context)
            {
                context.BeginRequest += new EventHandler(context_BeginRequest);
                context.EndRequest += new EventHandler(context_EndRequest);
            }
    
            void context_EndRequest(object sender, EventArgs e)
            {
                HttpApplication app = sender as HttpApplication;
                app.CompleteRequest();
                app.Dispose();
            }
    
            void context_BeginRequest(object sender, EventArgs e)
            {
                //your code here
            }
    
            #endregion
        }
