    using System;
    using System.ServiceProcess;
    
    namespace Cron
    {
        public class CronService : ServiceBase
        {
            public CronService()
            {
                this.ServiceName = "Cron";
                this.CanStop = true;
                this.CanPauseAndContinue = false;
                this.AutoLog = true;
            }
    
            protected override void OnStart(string[] args)
            {
               // TODO: add startup stuff
            }
    
            protected override void OnStop()
            {
               // TODO: add shutdown stuff
            }
        }
    }
