    var sessionOptions = new DComSessionOptions
    {
        Timeout = TimeSpan.FromSeconds(30)
    };
    var cimSession = CimSession.Create("localhost", sessionOptions);
    
    var volumes = cimSession.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Volume");
    
    foreach (var volume in volumes)
    {
        Console.WriteLine(volume.CimInstanceProperties["Name"].Value);
    }
