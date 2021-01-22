    int waveInDevices = WaveIn.DeviceCount;
    for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
    {
        WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
        Console.WriteLine("Device {0}: {1}, {2} channels", waveInDevice, deviceInfo.ProductName, deviceInfo.Channels);
    }
