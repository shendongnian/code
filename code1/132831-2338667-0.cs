    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Management;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            public static string GetProcessOwner(int PID, out string User)
            {
                string DummyStr = String.Empty;
                User = String.Empty;
                string ProcessStr = String.Empty;
                try
                {
                    ObjectQuery WMIQuery = new ObjectQuery(string.Format("Select * from Win32_Process Where ProcessID ={0}", PID.ToString()));
                    ManagementObjectSearcher WMIResult = new ManagementObjectSearcher(WMIQuery);
                    if (WMIResult.Get().Count == 0) return DummyStr;
                    foreach (ManagementObject oItem in WMIResult.Get())
                    {
                        string[] List = new String[2];
                        oItem.InvokeMethod("GetOwner", (object[])List);
                        ProcessStr = (string)oItem["Name"];
                        User = List[0];
                        if (User == null) User = String.Empty;
                        string[] StrSID = new String[1];
                        oItem.InvokeMethod("GetOwnerSid", (object[])StrSID);
                        DummyStr = StrSID[0];
                        return DummyStr;
                    }
                }
                catch
                {
                    return DummyStr;
                }
                return DummyStr;
            }
    
            static void Main(string[] args)
            {
              string User;
    
                Process[] processList = Process.GetProcesses();
                foreach (Process p in processList)
                {
                    GetProcessOwner(p.Id,out User);
                    Console.WriteLine(p.Id.ToString()+' '+User);
    
                }
                Console.ReadLine();
    
    
            
            }
        }
    }
