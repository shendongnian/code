    BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
    BluetoothClient client = new BluetoothClient();
    BluetoothDeviceInfo[] devices = client.DiscoverDevices();
    foreach (BluetoothDeviceInfo device in devices)
    {
        Console.WriteLine(device.DeviceAddress);
    }
