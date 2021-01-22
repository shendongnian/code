    public static void RestartService(string serviceName, int timeoutMilliseconds)
    {
      ServiceController service = new ServiceController(serviceName);
      try
      {
        int millisec1 = Environment.TickCount;
        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
        service.Stop();
        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
    
        // count the rest of the timeout
        int millisec2 = Environment.TickCount;
        timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2-millisec1));
    
        service.Start();
        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
      }
      catch
      {
        // ...
      }
    }
