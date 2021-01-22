    // Get the power state of a harddisk
    string ReportDiskStatus()
    {
        string status = string.Empty;
        bool fOn = false;
        Assembly assembly = Assembly.GetExecutingAssembly();
        FileStream[] files = assembly.GetFiles();
        if (files.Length > 0)
        {
            IntPtr hFile = files[0].Handle;
            bool result = GetDevicePowerState(hFile, out fOn);
            if (result)
            {
                if (fOn)
                {
                    status = "Disk is powered up and spinning";
                }
                else
                {
                    status = "Disk is sleeping";
                }
            }
            else
            {
                status = "Cannot get Disk Status";
            }
            Console.WriteLine(status);
        }
        return status;
    }
