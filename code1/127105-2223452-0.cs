    private static string GetDeviceName(DEV_BROADCAST_DEVICEINTERFACE dvi)
    {
        string[] Parts = dvi.dbcc_name.Split('#');
        if (Parts.Length >= 3)
        {
            string DevType = Parts[0].Substring(Parts[0].IndexOf(@"?\") + 2);
            string DeviceInstanceId = Parts[1];
            string DeviceUniqueID = Parts[2];
            string RegPath = @"SYSTEM\CurrentControlSet\Enum\" + DevType + "\\" + DeviceInstanceId + "\\" + DeviceUniqueID;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegPath);
            if (key != null)
            {
                object result = key.GetValue("FriendlyName");
                if (result != null)
                    return result.ToString();
                result = key.GetValue("DeviceDesc");
                if (result != null)
                    return result.ToString();
            }
        }
        return null;
    }
