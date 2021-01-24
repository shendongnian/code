      try
    {
    using( ServiceController sc = new ServiceController(name here) )
    {
        return sc.Status == ServiceControllerStatus.Running;
    }
    }
    catch( ArgumentException ) { return false; }
    catch( Win32Exception ) { return false; }
