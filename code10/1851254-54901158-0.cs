    var services = ServiceController.GetServices(machineName);
    
    var servicesList = new List<string>
                            {
                               "ACT! Service Host",
                               "ACT! Smart Task Service Host",
                               "ActConnectLink",
                               "SQL Server (ACT7)",
                               "SQL Server Browser",
                               "Act! Scheduler",
                               "APFWLicensingSrvc"
                            };
    
    var activeServices = services.Where(x => servicesList.Contains(x.ServiceName) && x.Status != ServiceControllerStatus.Stopped);
    foreach (var service in activeServices)
    {
       try
       {
          service.Stop();
       }
       catch (Exception e)
       {
          // maybe log something here
       }
    }
