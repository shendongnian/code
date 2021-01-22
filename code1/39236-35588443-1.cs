    using System.Management;
    
        public enum EventType
        {
            Inserted,
            Removed
        }
        ManagementEventWatcher watcher = new ManagementEventWatcher();
        WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");
        watcher.EventArrived += (s, e) =>
        {
             string DriveName = e.NewEvent.Properties["DriveName"].Value.ToString();
             Type = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));
        };
