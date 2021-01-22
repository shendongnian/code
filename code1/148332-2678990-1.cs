    ManagedComputer c = new ManagedComputer();
    //Get the SQL service and stop it if it's running
    Service svc = c.Services["MSSQL$SQLEXPRESS"];
    if (svc.ServiceState == ServiceState.Running)
    {
        svc.Stop();
    }
    //Connect to the SQLEXPRESS instance and change the port
    ServerInstance s = c.ServerInstances["MSSQL$SQLEXPRESS"];
    ServerProtocol prot = s.ServerProtocols["Tcp"];
    prot.IPAddresses[0].IPAddressProperties["TcpPort"].Value = "1433";
    //Commit the changes
    prot.Alter();
    //Restart the service
    svc.Start();
