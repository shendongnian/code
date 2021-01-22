    public class MonitorSample
    {
        static void Main() 
        {
            RegistryMonitor monitor = new 
              RegistryMonitor(RegistryHive.CurrentUser, "Environment");
            monitor.RegChanged += new EventHandler(OnRegChanged);
            monitor.Start();
     
            while(true);
            
            monitor.Stop();
        }
             
        private void OnRegChanged(object sender, EventArgs e)
        {
            Console.WriteLine("registry key has changed");
        }
    }
