    private void rebootHost(string hostName)
    {
        string adsiPath = string.Format(@"\\{0}\root\cimv2", hostName);
        ManagementScope scope = new ManagementScope(adsiPath);
        // I've seen this, but I found not necessary:
        // scope.Options.EnablePrivileges = true;
        ManagementPath osPath = new ManagementPath("Win32_OperatingSystem");
        ManagementClass os = new ManagementClass(scope, osPath, null);
    
        ManagementObjectCollection instances;
        try
        {
            instances = os.GetInstances();
        }
        catch (UnauthorizedAccessException exception)
        {
            throw new MyException("Not permitted to reboot the host: " + hostName, exception);
        }
        catch (COMException exception)
        {
            if (exception.ErrorCode == -2147023174)
            {
                throw new MyException("Could not reach the target host: " + hostName, exception);
            }
            throw; // Unhandled
        }
        foreach (ManagementObject instance in instances)
        {
            object result = instance.InvokeMethod("Reboot", new object[] { });
            uint returnValue = (uint)result;
    
            if (returnValue != 0)
            {
                throw new MyException("Failed to reboot host: " + hostName);
            }
        }
    }
