    public sealed class PageInitializerModule : IHttpModule
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(PageInitializerModule));
        }
        void IHttpModule.Init(HttpApplication app)
        {
            app.PreRequestHandlerExecute += (sender, e) => {
                var handler = app.Context.CurrentHandler;
                if (handler != null)
                {
                    string name = handler.GetType().Assembly.FullName;
                    if (!name.StartsWith("System.Web") &&
                        !name.StartsWith("Microsoft") &&
                        !name.StartsWith("Elmah")) // <----- ADDED THIS -----
                    {
                        Global.InitializeHandler(handler);
                    }
                }
            };
        }
        void IHttpModule.Dispose() { }
    }
