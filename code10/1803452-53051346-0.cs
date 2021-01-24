    // libs
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Renci.SshNet;
    namespace ConsoleApp
    {
        class Program
        {
            // Simple Host class
            public class CHost
            {
                public string IP;
                public string HostType;
                public CHost(string inType, string inIP)
                {// constructor
                    this.IP         = inIP;
                    this.HostType   = inType;
                }
            }
            // Call test function
            static void Main(string[] args)
            {
                // Create a set of hosts
                var HostList = new List<CHost>();
                HostList.Add( new CHost("Machine1", "10.52.0.93"));
                HostList.Add( new CHost("Machine1", "10.52.0.30"));
                HostList.Add( new CHost("Machine2", "10.52.0.34"));
            
                // Call async host reboot call
                RebootMachines(HostList);
            }
            // Reboot method
            public static async void RebootMachines(List<CHost> iHosts)
            {
                // Locals
                var tasks = new List<Task>();
                // Build list of Reboot calls - as a List of Tasks
                foreach(var host in iHosts)
                {
                    if (host.HostType == "Machine1")
                    {// machine type 1
                         var task = CallRestartMachine1(host.IP);
                        tasks.Add(task);    // Add task to task list
                    }
                    else if (host.HostType == "Machine2")
                    {// machine type 2
                        var task = CallRestartMachine2(host.IP);
                        tasks.Add(task);    // Add task to task list
                    }   
                }
                // Run all tasks in task list in parallel
                await Task.WhenAll(tasks);
            }
        
            // ASYNC METHODS until here
            private static async Task CallRestartMachine1(string host)
            {// helper method: reboot machines of type 1
                await Task.Run(() =>
                {
                    RebootByWritingAFile(@"D:\RebootMe.bm", "reboot");
                });
            }
            private static async Task CallRestartMachine2(string host)
            {// helper method: reboot machines of type 2
                await Task.Run(() =>
                {
                    RebootByNetwork(host, "user", "pwd");
                });
            }
            // STATIC METHODS here, going forward
            private static void RebootByWritingAFile(string inPath, string inText)
            {// This method does a lot of checks using more static methods, but then only writes a file
            
                try
                {
                    File.WriteAllText(inPath, inText); // static m
                }
                catch
                {
                    // do nothing for now
                }
            }
            private static void RebootByNetwork(string host, string user, string pass)
            {
                // Locals
                string rawASIC = "";
                SshClient SSHclient;
                SshCommand SSHcmd;
                // Send reboot command to linux machine
                try
                {
                    SSHclient = new SshClient(host, 22, user, pass);
                    SSHclient.Connect();
                    SSHcmd = SSHclient.RunCommand("exec /sbin/reboot");
                    rawASIC = SSHcmd.Result.ToString();
                    SSHclient.Disconnect();
                    SSHclient.Dispose();
                }
                catch
                {
                    // do nothing for now
                }
            }
        }
    }
