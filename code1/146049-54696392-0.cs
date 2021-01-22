    public partial class ProcessMonitor_Service : ServiceBase
    {
        public ProcessMonitor_Service()
        {
            InitializeComponent();            
            ProcessMonitor pm = new ProcessMonitor();
        }
        protected override void OnStart(string[] args)
        {
            
        }
        protected override void OnStop()
        {
            
        }
    }
	
	public class ProcessMonitor
	{
		public ProcessMonitor()
		{
			// start timers
			Console.ReadLine(); 
		}
	}
