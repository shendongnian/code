    #define RUN_AS_SERVICE
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.ServiceProcess;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
    #if RUN_AS_SERVICE
    
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                ServicesToRun = new System.ServiceProcess.ServiceBase[]
                {
                    new MyService()
                };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #else
                // Run as GUI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
    #endif
            }
        }
        public class MyService : ServiceBase
        {
            protected override void OnStart(string[] args)
            {
                // Start your service
            }
    
            protected override void OnStop()
            {
                // Stop your service
            }
        }
    }
