        using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName))
        {
             sc.Start();
        }
    }
