    ConnectionOptions op = new ConnectionOptions();
    op.Username = "Domain\\Domainuser";
    op.Password = "password";
    ManagementScope scope = new ManagementScope(@"\\Servername.Domain\root\cimv2", op);
    scope.Connect();
    ManagementPath path = new ManagementPath("Win32_Service");
    ManagementClass services;
    services = new ManagementClass(scope, path, null);
    
    foreach (ManagementObject service in services.GetInstances())
    {
    
    if (service.GetPropertyValue("State").ToString().ToLower().Equals("running"))
    { // Do something }
    
    }
    
