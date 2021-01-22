    class Program
        {
            static void Main(string[] args)
            {
                HostFactory.Run(x =>
                {
    
                    // setup service start and stop.
                    x.Service<Controller>(s =>
                    {
                        s.ConstructUsing(name => new Controller());
                        s.WhenStarted(controller => controller.Start());
                        s.WhenStopped(controller => controller.Stop());
                    });
    
                    // setup recovery here
                    x.EnableServiceRecovery(rc =>
                    {
                        rc.RestartService(delayInMinutes: 0);
                        rc.SetResetPeriod(days: 0);
                    });
    
                    x.RunAsLocalSystem();
                });
            }
    }
    public class Controller
        {
            public void Start()
            {
               
            }
    
            public void Stop()
            {
               
            }
        }
