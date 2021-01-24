    private static void Main(string[] args)
    {
        const uint ERROR_SUCCESS = 0;
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            try
            {
                uint returnValue = GetSecurityInfo(process.Handle,
                                                   SE_OBJECT_TYPE.SE_KERNEL_OBJECT,
                                                   SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION,
                                                   out IntPtr ownerSid,
                                                   out IntPtr groupSid,
                                                   out IntPtr dacl,
                                                   out IntPtr sacl,
                                                   out IntPtr securityDescriptor);
                if (returnValue != ERROR_SUCCESS)
                {
                    // If the function succeeds, the return value is ERROR_SUCCESS.
                    // If the function fails, the return value is a nonzero error code defined in WinError.h.
                    continue;
                }
                SecurityIdentifier securityIdentifier = new SecurityIdentifier(ownerSid);
                Console.WriteLine("Owner of process {0} is {1}", process.ProcessName, securityIdentifier);
                if (securityIdentifier.IsWellKnown(WellKnownSidType.LocalSystemSid))
                {
                    Console.WriteLine("Running under System Account");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to retrieve owner for process {0}: {1}", process.ProcessName, e.Message);
            }
        }
