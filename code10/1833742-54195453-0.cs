    public class MyModule1 : IHttpModule {
        public void Dispose() {
            //clean-up code here.
        }
    
        public void Init(HttpApplication application) {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            application.LogRequest += new EventHandler(OnLogRequest);
            application.BeginRequest += new EventHandler(OnBeginRequest);
        }
        public Func<object, HttpContextBase> GetContext = (object sender) => {
            return new HttpContextWrapper(((HttpApplication)sender).Context);
        };
    
        public void OnBeginRequest(object sender, EventArgs e) {
            var context = GetContext(sender);
            onbegin(context);
        }
    
        private void onbegin(HttpContextBase context) {
            // other header stuff goes here
            context.Server.TransferRequest("bobsyouruncle", true);
        }
    
        public void OnLogRequest(Object source, EventArgs e) {
            //custom logging logic can go here
        }
        //...
    }
