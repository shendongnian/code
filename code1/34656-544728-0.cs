    private enum SimpleServiceCustomCommands { KillProcess = 128 };
    ServiceControllerPermission scp = new ServiceControllerPermission(ServiceControllerPermissionAccess.Control, Environment.MachineName, "SERVICE_NAME");
    scp.Assert();
    System.ServiceProcess.ServiceController serviceCon = new System.ServiceProcess.ServiceController("SERVICE_NAME", Environment.MachineName);
    serviceCon.ExecuteCommand((int)SimpleServiceCustomCommands.KillProcess);
