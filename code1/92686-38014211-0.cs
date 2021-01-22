    public partial class Scheduler : ServiceBase
    {
        private Timer timer1 = null;
       
        public Scheduler()
        {
            InitializeComponent();
        }
        // Get the Exe path
        private string GetPath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.Combine(Path.GetDirectoryName(assembly.Location), "Test.exe");
           
        }
        // you can right your own custom code
        // Above vista version the process works as Administrator- "runas" and in old OS it will Start process as per Administartor rights  
        public void startprocess()
        {
           // System.Diagnostics.Process.Start(GetPath());
            System.Diagnostics.Process process = null;
            System.Diagnostics.ProcessStartInfo processStartInfo;
            processStartInfo = new System.Diagnostics.ProcessStartInfo();
            processStartInfo.FileName = GetPath();
            if (System.Environment.OSVersion.Version.Major >= 6)  // Windows Vista or higher
            {
                processStartInfo.Verb = "runas";
            }
            else
            {
                // No need to prompt to run as admin
            }
            processStartInfo.Arguments = "";
            
            process = System.Diagnostics.Process.Start(processStartInfo);
            
        }
        // On start method will load when system Start 
        // timer1_tick Event will call every hour after once start the service automatically
        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            timer1 = new Timer();
            this.timer1.Interval = 3600000; //every 60 min
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            
        }
     
        // Timer1_tick will Start process every hour
        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            //Write code here to do some job depends on your requirement
            startprocess();
        }
        // Method will stop the service
        // we have set the method stop service as false. so service will not stop and run every hour 
        protected override void OnStop()
        {
            timer1.Enabled = false;
        }
}
