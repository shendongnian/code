    using System.Linq;
    using System.Management;
    class Program
    {
        /// <summary>
        /// Adapted from https://www.codeproject.com/Articles/14828/How-To-Get-Process-Owner-ID-and-Current-User-SID
        /// </summary>
        public static void GetProcessOwnerByProcessId(int processId, out string user, out string domain)
        {
            user = "???";
            domain = "???";
            var sq = new ObjectQuery("Select * from Win32_Process Where ProcessID = '" + processId + "'");
            var searcher = new ManagementObjectSearcher(sq);
            if (searcher.Get().Count != 1)
            {
                return;
            }
            var process = searcher.Get().Cast<ManagementObject>().First();
            var ownerInfo = new string[2];
            process.InvokeMethod("GetOwner", ownerInfo);
            if (user != null)
            {
                user = ownerInfo[0];
            }
            if (domain != null)
            {
                domain = ownerInfo[1];
            }
        }
        public static void Main()
        {
            var processId = System.Diagnostics.Process.GetCurrentProcess().Id;
            string user;
            string domain;
            GetProcessOwnerByProcessId(processId, out user, out domain);
            System.Console.WriteLine(domain + "\\" + user);
        }
    }
