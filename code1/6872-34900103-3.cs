    // use `/ 1048576` to get ram in MB
    // and `/ (1048576 * 1024)` or `/ 1048576 / 1024` to get ram in GB
    private static String getRAMsize()
    {
        ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject item in moc)
        {
           return Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1048576, 0)) + " MB";
        }
 
        return "RAMsize";
    }
