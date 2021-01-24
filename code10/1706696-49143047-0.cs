    try
    {
        string interfaceId = @"...";
        string[] requestedProperties = { "System.Devices.AudioDevice.Microphone.SignalToNoiseRatioInDb", "System.Devices.AudioDevice.Microphone.SensitivityInDbfs" };
        DeviceInformation deviceInfo = await DeviceInformation.CreateFromIdAsync(interfaceId, requestedProperties, DeviceInformationKind.DeviceInterface); 
        object SignalToNoiseRatioInDb; 
        var allpro = deviceInfo.Properties.AsParallel();
        foreach (var one in allpro)
        {
            System.Diagnostics.Debug.WriteLine(one);
        }  
        var result = deviceInfo.Properties.TryGetValue("System.Devices.AudioDevice.Microphone.SignalToNoiseRatioInDb", out SignalToNoiseRatioInDb);
        System.Diagnostics.Debug.WriteLine(SignalToNoiseRatioInDb);
    }
