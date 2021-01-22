    using Elmah;
    using ElmahErrorLogModule = Elmah.ErrorLogModule;
    
    namespace XXXX
    {
        public class ErrorLogModule : ElmahErrorLogModule
        {
            protected override void OnErrorSignaled(object sender, ErrorSignalEventArgs args)
            {
                // Remove password from the server variables being serialized
                args.Context.Request.ServerVariables.Remove("AUTH_PASSWORD");
    
                //TODO: remove session id, cookie too?
    
                base.OnErrorSignaled(sender, args);
            }
        }
    }
