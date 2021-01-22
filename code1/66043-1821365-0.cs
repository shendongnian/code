    /// <summary>
    /// Checks to see if ActiveSync/Windows Mobile Device Center
    /// is installed on the PC.
    /// </summary>
    /// <param name="syncVersion">The version of the synchronization tool installed.</param>
    /// <returns>True: Either ActiveSync or Windows Mobile Device Center is 
    /// installed. False: version is null
    /// </returns>
    private static bool isActiveSyncInstalled(out Version syncVersion)
    {
                using (RegistryKey reg = 
                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows CE Services"))
                {
                    if (reg == null)
                    {
                        syncVersion = null;
                        return false;
                    }
                    
                    int majorVersion = (int)reg.GetValue("MajorVersion", 0);
                    int minorVersion = (int)reg.GetValue("MinorVersion", 0);
                    int buildNumber = (int)reg.GetValue("BuildNumber", 0);
    
                    syncVersion = new Version(majorVersion, minorVersion, buildNumber);
                }
                return true;
    }
