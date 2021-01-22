        IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties(); 
        IPEndPoint[] activeListeners = globalProperties.GetActiveTcpListeners(); 
        if (activeListeners.Any(conn => conn.Port == port)) 
        { 
            return true; 
        } 
        return false; 
 } 
