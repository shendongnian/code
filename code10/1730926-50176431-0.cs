    public class MonitorService
    {
        ManagementEventWatcher _managementEventWatcher;
        public IObservable<ProcessModel> NewProcessObservable { get; }
        public MonitorService()
        {
            var qStart = "SELECT * FROM Win32_ProcessStartTrace where ProcessName='chrome.exe'";
            _managementEventWatcher = new ManagementEventWatcher(new WqlEventQuery(qStart));
            var eventArrivedObservable = Observable.FromEventPattern<EventArrivedEventHandler, EventArrivedEventArgs>(
                x => _managementEventWatcher.EventArrived += x,
                x => _managementEventWatcher.EventArrived -= x);
            NewProcessObservable = eventArrivedObservable
                .Select(x => GetProcessModel(x.EventArgs))
                .Where(x => x != null);
        }
        public List<ProcessModel> GetProcesses()
        {
            List<ProcessModel> processes = new List<ProcessModel>();
            foreach(var process in Process.GetProcesses().Where(p => p.ProcessName.Contains("chrome")))
                processes.Add(new ProcessModel(process));
            return processes;
        }
        public void Start()
        {
            try
            {
                _managementEventWatcher.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void Stop()
        {
            if(_managementEventWatcher != null)
                _managementEventWatcher.Stop();
        }
        
        private ProcessModel GetProcessModel(EventArrivedEventArgs e)
        {
            ProcessModel model = null;
            try
            {
                Process process = Process.GetProcessById(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value));
                model = new ProcessModel(process);
            }
            catch(ArgumentException)
            {
                //log it
            }
            catch(InvalidOperationException)
            {
                //log it
            }
            return model;
        }
    }
