    public static string GetCpuArch()
    {
        ManagementScope scope = new ManagementScope();
        ObjectQuery query = new ObjectQuery("SELECT Architecture FROM Win32_Processor");
        ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
        ManagementObjectCollection results = search.Get();
        ManagementObjectCollection.ManagementObjectEnumerator e = results.GetEnumerator();
        e.MoveNext();
        ushort arch = (ushort)e.Current["Architecture"];
        switch (arch)
        {
            case 0:
                return "x86";
            case 1:
                return "MIPS";
            case 2:
                return "Alpha";
            case 3:
                return "PowerPC";
            case 6:
                return "Itanium";
            case 9:
                return "x64";
            default:
                return "Unknown Architecture (WMI ID " + arch.ToString() + ")";
        }
    }
