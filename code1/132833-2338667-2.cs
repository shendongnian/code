    using System;
    using System.Diagnostics;
    using System.Management;
    using System.Text;
    using System.Collections.Generic;
    
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            public static Dictionary<int, string> GetAllProcessOwners()
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                //string DummyStr = String.Empty;
                string User = String.Empty;
                string ProcessStr = String.Empty;
                try
                {
                    ObjectQuery WMIQuery = new ObjectQuery("Select * from Win32_Process");
                    ManagementObjectSearcher WMIResult = new ManagementObjectSearcher(WMIQuery);
                    if (WMIResult.Get().Count == 0) return d;
                    foreach (ManagementObject oItem in WMIResult.Get())
                    {
                        string[] List = new String[2];
                        oItem.InvokeMethod("GetOwner", (object[])List);
                        ProcessStr = (string)oItem["Name"];
                        User = List[0];
                        if (User == null) User = String.Empty;
                        //string[] StrSID = new String[1];
                        //oItem.InvokeMethod("GetOwnerSid", (object[])StrSID);
                        //DummyStr = StrSID[0];
                        d.Add(Convert.ToInt32(oItem["ProcessId"]), User);
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    return d;
                }
                return d;
            }
    
    
            static void Main(string[] args)
            {
                Dictionary<int, string> List = GetAllProcessOwners();
                Process[] processList = Process.GetProcesses();
                foreach (Process p in processList)
                {                                
                    if (List.ContainsKey(p.Id))
                    {
                        Console.WriteLine(p.Id.ToString() + ' ' + List[p.Id]);
                    }                
                }
            Console.ReadLine();
            }
        }
    }
