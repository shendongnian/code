    string UnpackFixed(byte[] data, System.Text.Encoding encoding)
    {
        int i;
        for (i = 0; i < data.Length; ++i)
            if(data[i] == (byte)0)
                break;
        return encoding.GetString(data, i);
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct DeviceInfo
    {
        uint32 maxScanrate;
        uint32 minScanrate;
        uint32 maxNumOfPoints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        byte type[];
    };
    DeviceInfo pDevInfo = new DeviceInfo();
    pDevInfo.type = new byte[32];
    int r4 = GetDeviceInfo(0, ref pDevInfo);
    Console.WriteLine("  - type: " + UnpackFixed(pDevInfo.type));
