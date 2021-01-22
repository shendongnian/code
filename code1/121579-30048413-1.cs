    foreach (var port in query)
    {
        Console.WriteLine("{0} - {1}", port.DeviceID, port.Name);
        var pnpDeviceId = port.PNPDeviceID.ToString();
        if(pnpDeviceId.Contains("BTHENUM"))
        {
            var bluetoothDeviceAddress = pnpDeviceId.Split('&')[4].Split('_')[0];
            if (bluetoothDeviceAddress.Length == 12 && bluetoothDeviceAddress != "000000000000")
            {
                Console.WriteLine(" - Address: {0}", bluetoothDeviceAddress);
            }
        }
    }
