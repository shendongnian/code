    System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController();
    sc.ServiceName = "service name";
    sc.MachineName = ".";// for local.  use windows machine name here for a remote service
    sc.Start();
    TimeSpan ts = new TimeSpan(0, 0, 0, 3, 0); // 3 sec
    sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, ts);
    if (sc.Status == System.ServiceProcess.ServiceControllerStatus.Running)
        Console.WriteLine("started");
    else
        Console.WriteLine("failed to start");
