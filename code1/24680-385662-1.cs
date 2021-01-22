    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;
    using System.Management;
    namespace WmiProc
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementScope ms = new System.Management.ManagementScope(
                    @"\\myserver\root\cimv2");
                var oq = new System.Management.ObjectQuery(
                    "SELECT * FROM Win32_Process where Name='myprocname'");
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
                ManagementObjectCollection procsCollection = query1.Get();
                Console.WriteLine("process count:{0}", procsCollection.Count);
            }
        }
    }
