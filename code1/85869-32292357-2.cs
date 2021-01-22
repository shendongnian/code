    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.ServiceProcess;
    using System.Runtime.InteropServices;
    
    namespace SystemControl
    {
        class Services
        {
            static string strPath = @"D:\";
            static void Main(string[] args)
            {
                string strServiceName = "WindowsService1";
                CreateFolderStructure(strPath);
                string svcPath = @"D:\Applications\MSC\Agent\bin\WindowsService1.exe";
                if (!IsInstalled(strServiceName))
                {
                    InstallAndStart(strServiceName, strServiceName, svcPath + " -k runservice");                
                }
                else
                {
                    Console.Write(strServiceName + " already installed. Do you want to Uninstalled the Service.Y/N.?");
                    string strKey = Console.ReadLine();
    
                    if (!string.IsNullOrEmpty(strKey) && (strKey.StartsWith("y")|| strKey.StartsWith("Y")))
                    {
                        StopService(strServiceName);
                        Uninstall(strServiceName);
                        ServiceLogs(strServiceName + " Uninstalled.!", strPath);
                        Console.Write(strServiceName + " Uninstalled.!");
                        Console.Read();
                    }
                }
            }
    
            #region "Environment Variables"
            public static string GetEnvironment(string name, bool ExpandVariables = true)
            {
                if (ExpandVariables)
                {
                    return System.Environment.GetEnvironmentVariable(name);
                }
                else
                {
                    return (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment\").GetValue(name, "", Microsoft.Win32.RegistryValueOptions.DoNotExpandEnvironmentNames);
                }
            }
    
            public static void SetEnvironment(string name, string value)
            {
                System.Environment.SetEnvironmentVariable(name, value);
            }
            #endregion
    
            #region "ServiceCalls Native"
            public static ServiceController[] List { get { return ServiceController.GetServices(); } }
    
            public static void Start(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                catch(Exception ex)
                {
                    // ...
                }
            }
    
            public static void Stop(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
                catch
                {
                    // ...
                }
            }
    
            public static void Restart(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);
                try
                {
                    int millisec1 = Environment.TickCount;
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
    
                    // count the rest of the timeout
                    int millisec2 = Environment.TickCount;
                    timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));
    
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                catch
                {
                    // ...
                }
            }
    
            public static bool IsInstalled(string serviceName)
            {
                // get list of Windows services
                ServiceController[] services = ServiceController.GetServices();
    
                // try to find service name
                foreach (ServiceController service in services)
                {
                    if (service.ServiceName == serviceName)
                        return true;
                }
                return false;
            }
            #endregion
    
            #region "ServiceCalls API"
            private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
            private const int SERVICE_WIN32_OWN_PROCESS = 0x00000010;
    
            [Flags]
            public enum ServiceManagerRights
            {
                Connect = 0x0001,
                CreateService = 0x0002,
                EnumerateService = 0x0004,
                Lock = 0x0008,
                QueryLockStatus = 0x0010,
                ModifyBootConfig = 0x0020,
                StandardRightsRequired = 0xF0000,
                AllAccess = (StandardRightsRequired | Connect | CreateService |
                EnumerateService | Lock | QueryLockStatus | ModifyBootConfig)
            }
    
            [Flags]
            public enum ServiceRights
            {
                QueryConfig = 0x1,
                ChangeConfig = 0x2,
                QueryStatus = 0x4,
                EnumerateDependants = 0x8,
                Start = 0x10,
                Stop = 0x20,
                PauseContinue = 0x40,
                Interrogate = 0x80,
                UserDefinedControl = 0x100,
                Delete = 0x00010000,
                StandardRightsRequired = 0xF0000,
                AllAccess = (StandardRightsRequired | QueryConfig | ChangeConfig |
                QueryStatus | EnumerateDependants | Start | Stop | PauseContinue |
                Interrogate | UserDefinedControl)
            }
    
            public enum ServiceBootFlag
            {
                Start = 0x00000000,
                SystemStart = 0x00000001,
                AutoStart = 0x00000002,
                DemandStart = 0x00000003,
                Disabled = 0x00000004
            }
    
            public enum ServiceState
            {
                Unknown = -1, // The state cannot be (has not been) retrieved.
                NotFound = 0, // The service is not known on the host server.
                Stop = 1, // The service is NET stopped.
                Run = 2, // The service is NET started.
                Stopping = 3,
                Starting = 4,
            }
    
            public enum ServiceControl
            {
                Stop = 0x00000001,
                Pause = 0x00000002,
                Continue = 0x00000003,
                Interrogate = 0x00000004,
                Shutdown = 0x00000005,
                ParamChange = 0x00000006,
                NetBindAdd = 0x00000007,
                NetBindRemove = 0x00000008,
                NetBindEnable = 0x00000009,
                NetBindDisable = 0x0000000A
            }
    
            public enum ServiceError
            {
                Ignore = 0x00000000,
                Normal = 0x00000001,
                Severe = 0x00000002,
                Critical = 0x00000003
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private class SERVICE_STATUS
            {
                public int dwServiceType = 0;
                public ServiceState dwCurrentState = 0;
                public int dwControlsAccepted = 0;
                public int dwWin32ExitCode = 0;
                public int dwServiceSpecificExitCode = 0;
                public int dwCheckPoint = 0;
                public int dwWaitHint = 0;
            }
    
            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerA")]
            private static extern IntPtr OpenSCManager(string lpMachineName, string lpDatabaseName, ServiceManagerRights dwDesiredAccess);
            [DllImport("advapi32.dll", EntryPoint = "OpenServiceA", CharSet = CharSet.Ansi)]
            private static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceRights dwDesiredAccess);
            [DllImport("advapi32.dll", EntryPoint = "CreateServiceA")]
            private static extern IntPtr CreateService(IntPtr hSCManager, string lpServiceName, string lpDisplayName, ServiceRights dwDesiredAccess, int dwServiceType, ServiceBootFlag dwStartType, ServiceError dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lp, string lpPassword);
            [DllImport("advapi32.dll")]
            private static extern int CloseServiceHandle(IntPtr hSCObject);
            [DllImport("advapi32.dll")]
            private static extern int QueryServiceStatus(IntPtr hService, SERVICE_STATUS lpServiceStatus);
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern int DeleteService(IntPtr hService);
            [DllImport("advapi32.dll")]
            private static extern int ControlService(IntPtr hService, ServiceControl dwControl, SERVICE_STATUS lpServiceStatus);
            [DllImport("advapi32.dll", EntryPoint = "StartServiceA")]
            private static extern int StartService(IntPtr hService, int dwNumServiceArgs, int lpServiceArgVectors);
    
            /// <summary>
            /// Takes a service name and tries to stop and then uninstall the windows serviceError
            /// </summary>
            /// <param name="ServiceName">The windows service name to uninstall</param>
            public static void Uninstall(string ServiceName)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect);
                try
                {
                    IntPtr service = OpenService(scman, ServiceName, ServiceRights.StandardRightsRequired | ServiceRights.Stop | ServiceRights.QueryStatus);
                    if (service == IntPtr.Zero)
                    {
                        throw new ApplicationException("Service not installed.");
                    }
                    try
                    {
                        StopService(service);
                        int ret = DeleteService(service);
                        if (ret == 0)
                        {
                            int error = Marshal.GetLastWin32Error();
                            throw new ApplicationException("Could not delete service " + error);
                        }
                    }
                    finally
                    {
                        CloseServiceHandle(service);
                    }
                }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Accepts a service name and returns true if the service with that service name exists
            /// </summary>
            /// <param name="ServiceName">The service name that we will check for existence</param>
            /// <returns>True if that service exists false otherwise</returns>
            public static bool ServiceIsInstalled(string ServiceName)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect);
                try
                {
                    IntPtr service = OpenService(scman, ServiceName,
                    ServiceRights.QueryStatus);
                    if (service == IntPtr.Zero) return false;
                    CloseServiceHandle(service);
                    return true;
                }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Takes a service name, a service display name and the path to the service executable and installs / starts the windows service.
            /// </summary>
            /// <param name="ServiceName">The service name that this service will have</param>
            /// <param name="DisplayName">The display name that this service will have</param>
            /// <param name="FileName">The path to the executable of the service</param>
            public static void InstallAndStart(string ServiceName, string DisplayName,
            string FileName)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect |
                ServiceManagerRights.CreateService);
                try
                {
                    string strKey = string.Empty;
                    IntPtr service = OpenService(scman, ServiceName,
                    ServiceRights.QueryStatus | ServiceRights.Start);
                    if (service == IntPtr.Zero)
                    {
                        service = CreateService(scman, ServiceName, DisplayName,
                        ServiceRights.QueryStatus | ServiceRights.Start, SERVICE_WIN32_OWN_PROCESS,
                        ServiceBootFlag.AutoStart, ServiceError.Normal, FileName, null, IntPtr.Zero,
                        null, null, null);
                        ServiceLogs(ServiceName + " Installed Sucessfully.!", strPath);
                        Console.Write(ServiceName + " Installed Sucessfully.! Do you want to Start the Service.Y/N.?");
                        strKey=Console.ReadLine();
                    }
                    if (service == IntPtr.Zero)
                    {
                        ServiceLogs("Failed to install service.", strPath);
                        throw new ApplicationException("Failed to install service.");
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(strKey) && (strKey.StartsWith("y") || strKey.StartsWith("Y")))
                        {
                            StartService(service);
                            ServiceLogs(ServiceName + " Started Sucessfully.!", strPath);
                            Console.Write(ServiceName + " Started Sucessfully.!");
                            Console.Read();
                        }
                    }
                    finally
                    {
                        CloseServiceHandle(service);
                    }
                }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Takes a service name and starts it
            /// </summary>
            /// <param name="Name">The service name</param>
            public static void StartService(string Name)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect);
                try
                {
                    IntPtr hService = OpenService(scman, Name, ServiceRights.QueryStatus |
                    ServiceRights.Start);
                    if (hService == IntPtr.Zero)
                    {
                        ServiceLogs("Could not open service.", strPath);
                        throw new ApplicationException("Could not open service.");
                    }
                    try
                    {
                        StartService(hService);
                    }
                    finally
                    {
                        CloseServiceHandle(hService);
                    }
                }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Stops the provided windows service
            /// </summary>
            /// <param name="Name">The service name that will be stopped</param>
            public static void StopService(string Name)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect);
                try
                {
                    IntPtr hService = OpenService(scman, Name, ServiceRights.QueryStatus |
                    ServiceRights.Stop);
                    if (hService == IntPtr.Zero)
                    {
                        ServiceLogs("Could not open service.", strPath);
                        throw new ApplicationException("Could not open service.");
                    }
                    try
                    {
                        StopService(hService);
                    }
                    finally
                    {
                        CloseServiceHandle(hService);
                    }
    
            
    
    }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Stars the provided windows service
            /// </summary>
            /// <param name="hService">The handle to the windows service</param>
            private static void StartService(IntPtr hService)
            {
                SERVICE_STATUS status = new SERVICE_STATUS();
                StartService(hService, 0, 0);
                WaitForServiceStatus(hService, ServiceState.Starting, ServiceState.Run);
            }
    
            /// <summary>
            /// Stops the provided windows service
            /// </summary>
            /// <param name="hService">The handle to the windows service</param>
            private static void StopService(IntPtr hService)
            {
                SERVICE_STATUS status = new SERVICE_STATUS();
                ControlService(hService, ServiceControl.Stop, status);
                WaitForServiceStatus(hService, ServiceState.Stopping, ServiceState.Stop);
            }
    
            /// <summary>
            /// Takes a service name and returns the <code>ServiceState</code> of the corresponding service
            /// </summary>
            /// <param name="ServiceName">The service name that we will check for his <code>ServiceState</code></param>
            /// <returns>The ServiceState of the service we wanted to check</returns>
            public static ServiceState GetServiceStatus(string ServiceName)
            {
                IntPtr scman = OpenSCManager(ServiceManagerRights.Connect);
                try
                {
                    IntPtr hService = OpenService(scman, ServiceName,
                    ServiceRights.QueryStatus);
                    if (hService == IntPtr.Zero)
                    {
                        return ServiceState.NotFound;
                    }
                    try
                    {
                        return GetServiceStatus(hService);
                    }
                    finally
                    {
                        CloseServiceHandle(scman);
                    }
                }
                finally
                {
                    CloseServiceHandle(scman);
                }
            }
    
            /// <summary>
            /// Gets the service state by using the handle of the provided windows service
            /// </summary>
            /// <param name="hService">The handle to the service</param>
            /// <returns>The <code>ServiceState</code> of the service</returns>
            private static ServiceState GetServiceStatus(IntPtr hService)
            {
                SERVICE_STATUS ssStatus = new SERVICE_STATUS();
                if (QueryServiceStatus(hService, ssStatus) == 0)
                {
                    ServiceLogs("Failed to query service status.", strPath);
                    throw new ApplicationException("Failed to query service status.");
                }
                return ssStatus.dwCurrentState;
            }
    
            /// <summary>
            /// Returns true when the service status has been changes from wait status to desired status
            /// ,this method waits around 10 seconds for this operation.
            /// </summary>
            /// <param name="hService">The handle to the service</param>
            /// <param name="WaitStatus">The current state of the service</param>
            /// <param name="DesiredStatus">The desired state of the service</param>
            /// <returns>bool if the service has successfully changed states within the allowed timeline</returns>
            private static bool WaitForServiceStatus(IntPtr hService, ServiceState
            WaitStatus, ServiceState DesiredStatus)
            {
                SERVICE_STATUS ssStatus = new SERVICE_STATUS();
                int dwOldCheckPoint;
                int dwStartTickCount;
    
                QueryServiceStatus(hService, ssStatus);
                if (ssStatus.dwCurrentState == DesiredStatus) return true;
                dwStartTickCount = Environment.TickCount;
                dwOldCheckPoint = ssStatus.dwCheckPoint;
    
                while (ssStatus.dwCurrentState == WaitStatus)
                {
                    // Do not wait longer than the wait hint. A good interval is
                    // one tenth the wait hint, but no less than 1 second and no
                    // more than 10 seconds.
    
                    int dwWaitTime = ssStatus.dwWaitHint / 10;
    
                    if (dwWaitTime < 1000) dwWaitTime = 1000;
                    else if (dwWaitTime > 10000) dwWaitTime = 10000;
    
                    System.Threading.Thread.Sleep(dwWaitTime);
    
                    // Check the status again.
    
                    if (QueryServiceStatus(hService, ssStatus) == 0) break;
    
                    if (ssStatus.dwCheckPoint > dwOldCheckPoint)
                    {
                        // The service is making progress.
                        dwStartTickCount = Environment.TickCount;
                        dwOldCheckPoint = ssStatus.dwCheckPoint;
                    }
                    else
                    {
                        if (Environment.TickCount - dwStartTickCount > ssStatus.dwWaitHint)
                        {
                            // No progress made within the wait hint
                            break;
                        }
                    }
                }
                return (ssStatus.dwCurrentState == DesiredStatus);
            }
    
            /// <summary>
            /// Opens the service manager
            /// </summary>
            /// <param name="Rights">The service manager rights</param>
            /// <returns>the handle to the service manager</returns>
            private static IntPtr OpenSCManager(ServiceManagerRights Rights)
            {
                IntPtr scman = OpenSCManager(null, null, Rights);
                if (scman == IntPtr.Zero)
                {
                    try
                    {
                        throw new ApplicationException("Could not connect to service control manager.");
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return scman;
            }
    
            #endregion
    
            #region"CreateFolderStructure"
            private static void CreateFolderStructure(string path)
            {
                if(!System.IO.Directory.Exists(path+"Applications"))
                    System.IO.Directory.CreateDirectory(path+ "Applications");
                if (!System.IO.Directory.Exists(path + "Applications\\MSC"))
                    System.IO.Directory.CreateDirectory(path + "Applications\\MSC");
                if (!System.IO.Directory.Exists(path + "Applications\\MSC\\Agent"))
                    System.IO.Directory.CreateDirectory(path + "Applications\\MSC\\Agent");
                if (!System.IO.Directory.Exists(path + "Applications\\MSC\\Agent\\bin"))
                    System.IO.Directory.CreateDirectory(path + "Applications\\MSC\\Agent\\bin");
                if (!System.IO.Directory.Exists(path + "Applications\\MSC\\AgentService"))
                    System.IO.Directory.CreateDirectory(path + "Applications\\MSC\\AgentService");
                
                string fullPath = System.IO.Path.GetFullPath("MSCService");
                if (System.IO.Directory.Exists(fullPath))
                {
                    foreach (string strFile in System.IO.Directory.GetFiles(fullPath))
                    {
                        if (System.IO.File.Exists(strFile))
                        {
                            String[] strArr = strFile.Split('\\');
                            System.IO.File.Copy(strFile, path + "Applications\\MSC\\Agent\\bin\\"+ strArr[strArr.Count()-1], true);
                        }
                    }
                }            
            }
            #endregion
    
            private static void ServiceLogs(string strLogInfo, string path)
            {
                string filePath = path + "Applications\\MSC\\AgentService\\ServiceLogs.txt";            
                System.IO.File.AppendAllLines(filePath, (strLogInfo + "--" + DateTime.Now.ToString()).ToString().Split('|'));
            }
        }
    }
