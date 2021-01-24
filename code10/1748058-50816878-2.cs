    public class MyService : ServiceBase
    {
        private ServiceHost serviceHost;
        protected override void OnStart(string[] args)
        {
          serviceHost = /* new, etc. */
          // Somehow pass the serviceHost reference to your library,
          // then subscribe to `Closed`, e.g.
          
          
          MyLibraryClass.Initialize(serviceHost);
          serviceHost.Open();
        }
        protected override void OnShutdown()
        {
          serviceHost.Close();
          // Do additional cleanup, e.g. stopping your "library threads"
          // Alternative to the event-approach in "OnStart", simply call
          MyLibraryClass.Shutdown();
        }
    }
