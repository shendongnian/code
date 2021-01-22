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
             object x = s;
             EventArrivedEventArgs ee = e;
             string DriveName = "";
             EventType Type;
             foreach(PropertyData pd in e.NewEvent.Properties)
             {
                 if (pd.Name == "DriveName") DriveName = (string)pd.Value; //the drive letter + :
                 if (pd.Name == "EventType") Type = (int)pd.Value == 2 ? EventType.Inserted : EventType.Removed;
             }
        };
