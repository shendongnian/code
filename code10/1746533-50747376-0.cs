    var services = ServiceController.GetServices("MyRemotePC");
    var getOptions = new ObjectGetOptions(null, TimeSpan.MaxValue, true);
    var scope = new ManagementScope(@"\\MyRemotePC\root\cimv2");
    foreach (ServiceController service in services)
    {
        Console.WriteLine($"The {service.DisplayName} service is currently {service.Status}.");
        if (service.Status != ServiceControllerStatus.Stopped)
        {
            var svcObj = new ManagementObject(scope, new ManagementPath($"Win32_Service.Name='{service.ServiceName}'"), getOptions);
            var processId = (uint)svcObj["ProcessID"];
            var searcher = new ManagementObjectSearcher(scope, new SelectQuery($"SELECT * FROM Win32_Process WHERE ProcessID = '{processId}'"));
            var processObj = searcher.Get().Cast<ManagementObject>().First();
            var props = processObj.Properties.Cast<PropertyData>().ToDictionary(x => x.Name, x => x.Value);
            string[] outArgs = new string[] { string.Empty, string.Empty };
            var returnVal = (UInt32)processObj.InvokeMethod("GetOwner", outArgs);
            if (returnVal == 0)
            {
                var userName = outArgs[1] + "\\" + outArgs[0];
                Console.WriteLine(userName);
            }
        }
    }
