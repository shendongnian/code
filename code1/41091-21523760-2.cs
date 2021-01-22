    Device device = android.GetConnectedDevice(
        android.ConnectedDevices[0]);
    objArray = new object[] { "ls", 
        string.Concat(thing,stringPath,thing)) };
    str = Adb.ExecuteAdbCommand(
        Adb.FormAdbCommand(device, "shell", objArray));
