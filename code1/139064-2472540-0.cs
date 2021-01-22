    Server server = new Server("localhost");
    BackupDevice newDevice = new BackupDevice();
    newDevice.Parent = server;
    newDevice.Name = "newDevice";
    newDevice.BackupDeviceType = BackupDeviceType.Disk;
    newDevice.PhysicalLocation = "c:\temp\newdevice.bak";
    newDevice.Create();
