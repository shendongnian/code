    var iotHubConnectionString = "MyIotHubConnectionString";
    var deviceId = "MyDeviceId";
    var moduleId = "MyModuleId";
    var methodName = "MyDirectMethodName";
    var payload = "MyJsonPayloadString";
    
    var cloudToDeviceMethod = new CloudToDeviceMethod(methodName, TimeSpan.FromSeconds(10));
    cloudToDeviceMethod.SetPayloadJson(payload);
    ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(iotHubConnectionString);
       
    try
    {
        var methodResult = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, cloudToDeviceMethod);
        if(methodResult.Status == 200)
        {
            // Handle Success
        }
        else if (methodResult.Status == 500)
        {
            // Handle Failure
        }
     }
     catch (Exception e)
     {
         // Device does not exist or is offline
         Console.WriteLine(e.Message);
     }
    
    
