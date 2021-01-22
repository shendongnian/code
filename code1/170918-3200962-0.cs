     WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM Win32_DeviceChangeEvent");
    
     ManagementEventWatcher watcher = new ManagementEventWatcher(query);
     watcher.EventArrived += 
                    new EventArrivedEventHandler(HandleEvent);
     // Start listening for events
                watcher.Start();
        .........
     // Stop listening for events
     watcher.Stop();
