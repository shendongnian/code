    using System;
    namespace WindowsServiceTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Management.SelectQuery sQuery = new System.Management.SelectQuery(string.Format("select name, startname from Win32_Service")); // where name = '{0}'", "MCShield.exe"));
                using (System.Management.ManagementObjectSearcher mgmtSearcher  = new System.Management.ManagementObjectSearcher(sQuery))
                {
                    foreach (System.Management.ManagementObject service in mgmtSearcher.Get())
                    {
                        string servicelogondetails =
                            string.Format("Name: {0} ,  Logon : {1} ", service["Name"].ToString(), service["startname"]).ToString();
                        Console.WriteLine(servicelogondetails);
                    }
                }
                Console.ReadLine();
            }
        }
    }
