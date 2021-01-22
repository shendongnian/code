    public static string GetProcessPath(int processId)
    {
        string MethodResult = "";
        try
        {
            string Query = "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(Query))
            {
                using (ManagementObjectCollection moc = mos.Get())
                {
                    string ExecutablePath = (from mo in moc.Cast<ManagementObject>() select mo["ExecutablePath"]).First().ToString();
                    MethodResult = ExecutablePath;
                }
            }
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }
