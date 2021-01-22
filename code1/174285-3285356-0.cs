    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Runtime.InteropServices;
    using System.ServiceProcess;
    
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
    			InitializeComponent();
    		}
    		[DllImport("kernel32.dll")]
    		public static extern bool Beep(int BeepFreq, int BeepDuration);
    
    		protected override void OnStart(string[] args)
    		{
    			Beep(900, 100);
    			Beep(800, 100);
    			this.Stop();
    		}
    
    		protected override void OnStop()
    		{
    		}
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
    			serviceInstaller.ServiceName = "Beeper";
    			serviceInstaller.ServicesDependedOn = new string[] { "TermService" };
    			Installers.Add(serviceInstaller);
    			Installers.Add(processInstaller);
    		}
    	}
    }
