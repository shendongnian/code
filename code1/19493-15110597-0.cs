    private string GetUserName(string procName)
    {
        string query = "SELECT * FROM Win32_Process WHERE Name = \'" + procName + "\'";
        var procs = new System.Management.ManagementObjectSearcher(query);
        foreach (System.Management.ManagementObject p in procs.Get())
        {
            var path = p["ExecutablePath"];
            if (path != null)
            {
                string executablePath = path.ToString();
                string[] ownerInfo = new string[2];
                p.InvokeMethod("GetOwner", (object[])ownerInfo);
                return ownerInfo[0];
            }
        }
        return null;
    }
