    using System.Management
    public static bool SetDefaultPrinter(string defaultPrinter)
    {
        using (ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
        {
            using (ManagementObjectCollection objectCollection = objectSearcher.Get())
            {
                foreach (ManagementObject mo in objectCollection)
                {
                    if (string.Compare(mo["Name"].ToString(), defaultPrinter, true) == 0)
                    {
                        mo.InvokeMethod("SetDefaultPrinter", null, null);
                        return true;
                    }
                }
            }
        }
        return false;
    }
