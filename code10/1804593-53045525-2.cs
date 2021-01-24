    public class MvcApplication : System.Web.HttpApplication
    {
        static Task Demo = null;
        static CancellationTokenSource TokenSource = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
    
    
            TokenSource = new CancellationTokenSource();
            CancellationToken Ct = TokenSource.Token;
    
            Demo = Task.Run(() =>
            {
                do
                {
                    Thread.Sleep(1000);
                    Trace.Write("loop");
                } while (!Ct.IsCancellationRequested);
            }, Ct);
        }
    
        public static void CancelLoop()
        {
            TokenSource.Cancel();
        }
    }
