      /// <summary>
    /// Wait (up to a timeout) for the MSI installer service to become free.
    /// </summary>
    /// <returns>
    /// Returns true for a successful wait, when the installer service has become free.
    /// Returns false when waiting for the installer service has exceeded the timeout.
    /// </returns>
    public static bool IsMsiExecFree(TimeSpan maxWaitTime)
    {
        // The _MSIExecute mutex is used by the MSI installer service to serialize installations
        // and prevent multiple MSI based installations happening at the same time.
        // For more info: http://msdn.microsoft.com/en-us/library/aa372909(VS.85).aspx
        const string installerServiceMutexName = "Global\\_MSIExecute";
        Mutex MSIExecuteMutex = null;
        var isMsiExecFree = false;
        try
        {
                MSIExecuteMutex = Mutex.OpenExisting(installerServiceMutexName,
                                System.Security.AccessControl.MutexRights.Synchronize);
                isMsiExecFree = MSIExecuteMutex.WaitOne(maxWaitTime, false);
        }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Mutex doesn't exist, do nothing
                isMsiExecFree = true;
            }
            catch (ObjectDisposedException)
            {
                // Mutex was disposed between opening it and attempting to wait on it, do nothing
                isMsiExecFree = true;
            }
            finally
            {
                if(MSIExecuteMutex != null && isMsiExecFree)
                MSIExecuteMutex.ReleaseMutex();
            }
        return isMsiExecFree;
 
    }
