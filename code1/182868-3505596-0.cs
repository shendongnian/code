    int numDev = HLP_GetNumDevices();
            
    string[] names = new string[numDev];
    for (int i = 0; i < names.Length; i++)
    {
        names[i] = new StringBuilder().Append(' ', 256).ToString();
    }
    ushort errorCode = HLP_GetDeviceNames(names, 256, Convert.ToUInt16(numDev));
