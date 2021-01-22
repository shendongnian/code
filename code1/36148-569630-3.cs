    using System;
    using System.ServiceProcess;
    
    namespace Cron
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                System.ServiceProcess.ServiceBase.Run(new CronService());
            }
        }
    }
