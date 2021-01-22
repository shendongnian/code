    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Runtime.InteropServices;
    using System.ServiceProcess;
    using System.Threading;
    
    namespace Beeper
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
        			{ 
        				new Beeper() 
        			};
                ServiceBase.Run(ServicesToRun);
            }
        }
    
        public partial class Beeper : ServiceBase
        {
            public Beeper()
            {
            }
    
            protected override void OnStart(string[] args)
            {
                if (MainThread != null)
                    MainThread.Abort();
                MainThread = new Thread(new ThreadStart(MainLoop));
                MainThread.Start();
            }
    
            protected override void OnStop()
            {
                if (MainThread != null)
                    MainThread.Abort();
            }
    
            protected void MainLoop()
            {
                try
                {
                    //main code here
                }
                catch (ThreadAbortException)
                {
                    //Do cleanup code here.
                }
            }
    
            System.Threading.Thread MainThread;
        }
        [RunInstaller(true)]
        public class BeeperInstaller : Installer
        {
            private ServiceProcessInstaller processInstaller;
            private ServiceInstaller serviceInstaller;
            public BeeperInstaller()
            {
                processInstaller = new ServiceProcessInstaller();
                serviceInstaller = new ServiceInstaller();
                processInstaller.Account = ServiceAccount.LocalSystem;
                serviceInstaller.StartType = ServiceStartMode.Automatic;
                serviceInstaller.ServiceName = "MyProgram";
                serviceInstaller.ServicesDependedOn = new string[] { "TermService" }; //Optional, this line makes sure the terminal services is up and running before it starts.
                Installers.Add(serviceInstaller);
                Installers.Add(processInstaller);
            }
        }
    }
