You can use [System.Management.MangementObjectSearcher][1] to get the process ID of a service and [System.Diagnostics.Process][2] to get the corresponding Process instance and kill it.
The KillService() in the following program shows how to do this:
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
namespace KillProcessApp {
    class Program {
        static void Main(string[] args) {
            KillService("YourServiceName");
        }
        static void KillService(string serviceName) {
            string query = string.Format(
                "SELECT ProcessId FROM Win32_Service WHERE Name='{0}'", 
                serviceName);
            ManagementObjectSearcher searcher = 
                new ManagementObjectSearcher(query);
            foreach (ManagementObject obj in searcher.Get()) {
                uint processId = (uint) obj["ProcessId"];
                Process process = null;
                try
                {
                    process = Process.GetProcessById((int)processId);
                }
                catch (ArgumentException)
                {
                    // Thrown if the process specified by processId
                    // is no longer running.
                }
                try
                {
                    if (process != null) 
                    {
                        process.Kill();
                    }
                }
                catch (Win32Exception)
                {
                    // Thrown if process is already terminating,
                    // the process is a Win16 exe or the process
                    // could not be terminated.
                }
                catch (InvalidOperationException)
                {
                    // Thrown if the process has already terminated.
                }
            }
        }
    }
}
