    public static void InstallAndStart(string serviceName, string displayName, string fileName, string username, string password)
            {
                IntPtr scm = OpenSCManager(ScmAccessRights.AllAccess);
                try
                {
                    IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.AllAccess);
                    
                    if (service == IntPtr.Zero)
                        service = CreateService(scm, serviceName, displayName, ServiceAccessRights.AllAccess, SERVICE_WIN32_OWN_PROCESS, ServiceBootFlag.AutoStart, ServiceError.Normal, fileName, null, IntPtr.Zero, null, username, password);
                    if (service == IntPtr.Zero)
                        throw new ApplicationException("Failed to install service.");
                    try
                    {
                        StartService(service);
                    }
                    finally
                    {
                        CloseServiceHandle(service);
                    }
                }
                finally
                {
                    CloseServiceHandle(scm);
                }
            }
