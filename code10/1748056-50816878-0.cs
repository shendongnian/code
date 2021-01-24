    public class MyService : ServiceBase
    {
        private ServiceHost serviceHost;
        protected override void OnStart(string[] args)
        {
          serviceHost = /* new, etc. */
          serviceHost.Open();
        }
        protected override void OnShutdown()
        {
          serviceHost.Close();
          // Do additional cleanup, e.g. stopping your "library threads"
        }
    }
