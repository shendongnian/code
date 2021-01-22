    //Source: https://stackoverflow.com/a/7139986/16911
    //Get all installed named instances.
    var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
    var rk = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server");
    var instances = (String[])rk.GetValue("InstalledInstances");
    List<String> sqlServices = instances.Select(x => "MSSQL$" + x).ToList();
    //Add SQLSERVEREXPRESS and MSSQLSERVER, if they exist.
    if(DoesServiceExist("SQLSERVEREXPRESS")) {
        sqlServices.Add("SQLSERVEREXPRESS");
    }
    if(DoesServiceExist("MSSQLSERVER")) {
        sqlServices.Add("MSSQLSERVER");
    }
    service.ServicesDependedOn = sqlServices.ToArray();
