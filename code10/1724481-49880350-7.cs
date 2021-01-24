      using System.ServiceProcess;
      ServiceController sc = new ServiceController(SERVICENAME);
      switch (sc.Status)
      {
        case ServiceControllerStatus.Running:
        return "Running";
      }
