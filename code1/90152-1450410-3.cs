    MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
    foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.All))
    {
        Console.WriteLine("{0}, {1}", device.FriendlyName, device.State);
    }
