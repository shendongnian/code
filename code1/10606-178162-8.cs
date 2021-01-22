    try
    {
        using( ServiceController sc = new ServiceController( SERVICE_NAME ) )
        {
            return sc.Status == ServiceControllerStatus.Running;
        }
    }
    catch( ArgumentException ) { return false; }
    catch( Win32Exception ) { return false; }
