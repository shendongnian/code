        var enumerator = new MMDeviceEnumerator();
        var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        while (true)
        {
            for (int i = 0;i< device.AudioMeterInformation.PeakValues.Count;i++)
            {
                Console.WriteLine("ID: " + i + " : " + device.AudioMeterInformation.PeakValues[i]);
            }
        }
