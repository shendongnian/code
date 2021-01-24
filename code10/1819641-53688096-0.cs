    public static void Main()
    {
        string MachineName = "[Name]";
        var ctl = ServiceController.GetServices(MachineName);
        List<string> namelist = new List<string>();
        foreach (var x in ctl)
        {
            if (x.DisplayName == "NHS Card Checker")
            {
                Console.WriteLine(string.Format("NHS Card checker found on MPC - Status: {0}", x.Status));
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                ManagementScope scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", MachineName));
                scope.Connect();
                string wmiQuery = string.Format("Select * from Win32_Service WHERE DisplayName='{0}'" , x.DisplayName);
                ManagementObjectSearcher wmi = new ManagementObjectSearcher(wmiQuery);
                ManagementObjectCollection coll = wmi.Get();
                foreach (var service in coll)
                {
                    Console.WriteLine(string.Format("{0} - {1}", service["Name"].ToString(), service["StartMode"].ToString()));
                }
            }
        }
        Console.ReadKey();
    }
