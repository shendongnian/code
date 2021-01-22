    using System;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Management;
    class Program
    {
        static void Main(string[] args)
        {
            foreach (ServiceController scTemp in ServiceController.GetServices())
            {
                if (scTemp.Status == ServiceControllerStatus.Stopped)
                    continue;    // stopped, so no process ID!
    
                ManagementObject service = new ManagementObject(@"Win32_service.Name='" + scTemp.ServiceName + "'");
                object o = service.GetPropertyValue("ProcessId");
                int processId = (int) ((UInt32) o);
                Process process = Process.GetProcessById(processId);
                Console.WriteLine("Service: {0}, Process ID: {1}", scTemp.ServiceName, processId);
            }
        }
    }
 
