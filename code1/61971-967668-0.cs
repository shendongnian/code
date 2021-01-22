     void WaitForProcess()
    {
        ManagementEventWatcher startWatch = new ManagementEventWatcher(
          new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
        startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
        startWatch.Start();
        ManagementEventWatcher stopWatch = new ManagementEventWatcher(
          new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
        stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
        stopWatch.Start();
        Console.ReadLine();
        startWatch.Stop();
        stopWatch.Stop();
    }
    
      static void stopWatch_EventArrived(object sender, EventArrivedEventArgs e) {
        Console.WriteLine("Process stopped: {0}", e.NewEvent.Properties["ProcessName"].Value);
      }
    
      static void startWatch_EventArrived(object sender, EventArrivedEventArgs e) {
        Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
      }
    }
