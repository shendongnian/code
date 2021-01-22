    Device device = android.GetConnectedDevice(android.ConnectedDevices[0]);
    
    objArray = new object[] { "ls", string.Concat("/sdcard/")) };
   
    str = Adb.ExecuteAdbCommand(Adb.FormAdbCommand(device, "shell", objArray));
    // or 
    // str= Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell",objArray));
