    var enumerator = new MMDeviceEnumerator();
    foreach (var endpoint in 
             enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
    {
        Console.WriteLine(endpoint.FriendlyName);
    }
