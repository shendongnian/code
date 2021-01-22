    public string GetProcessOwner(string processName)
    {
        string query = "Select * from Win32_Process Where Name = \"" + processName + "\"";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        ManagementObjectCollection processList = searcher.Get();
        foreach (ManagementObject obj in processList)
        {
            string[] argList = new string[] { string.Empty, string.Empty };
            int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
            if (returnVal == 0)
            {
                // return DOMAIN\user
                string owner = argList[1] + "\\" + argList[0];
       
            }
        }
        return "NO OWNER";
    }
