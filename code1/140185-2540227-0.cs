    public void EnableSqlServerTcp(string serverName, string instanceName)
    {
        ManagementScope scope =
                new ManagementScope(@"\\" + serverName +
                                    @"\root\Microsoft\SqlServer\ComputerManagement");
        ManagementClass sqlService =
                new ManagementClass(scope,
                                    new ManagementPath("SqlService"), null);
        ManagementClass serverProtocol =
                new ManagementClass(scope,
                                    new ManagementPath("ServerNetworkProtocol"), null);
        sqlService.Get();
        serverProtocol.Get();
        foreach (ManagementObject prot in serverProtocol.GetInstances())
        {
            prot.Get();
            if ((string)prot.GetPropertyValue("ProtocolName") == "Tcp" &&
                (string)prot.GetPropertyValue("InstanceName") == instanceName)
            {
                prot.InvokeMethod("SetEnable", null);
            }
        }
        uint sqlServerService = 1;
        uint sqlServiceStopped = 1;
        foreach (ManagementObject instance in sqlService.GetInstances())
        {
            if ((uint)instance.GetPropertyValue("SqlServiceType") == sqlServerService &&
                (string)instance.GetPropertyValue("ServiceName") == instanceName)
            {
                instance.Get();
                if ((uint)instance.GetPropertyValue("State") != sqlServiceStopped)
                {
                    instance.InvokeMethod("StopService", null);
                }
                instance.InvokeMethod("StartService", null);
            }
        }
    }
