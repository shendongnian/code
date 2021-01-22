    string r = "";
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
    {
        ManagementObjectCollection information = searcher.Get();
        if (information != null)
        {
            foreach (ManagementObject obj in information)
            {
                r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
            }
        }
        r = r.Replace("NT 5.1.2600", "XP");
        r = r.Replace("NT 5.2.3790", "Server 2003");
        MessageBox.Show(r);
    }
