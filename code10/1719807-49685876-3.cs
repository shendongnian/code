    public int EnableOrDisableNetworkAdapter(string strOperation)
    {
       int resultEnableDisableNetworkAdapter = (int)EnumEnableDisableResult.Unknow;
       ManagementObject crtNetworkAdapter = new ManagementObject();
    
       string strWQuery = string.Format("SELECT DeviceID, ProductName, "
                                        + "NetEnabled, NetConnectionStatus "
                                        + "FROM Win32_NetworkAdapter " + "WHERE DeviceID = {0}", DeviceId);
    
       try
       {
          ManagementObjectCollection networkAdapters =
             WMIOperation.WMIQuery(strWQuery);
          foreach (ManagementObject networkAdapter in networkAdapters)
          {
             crtNetworkAdapter = networkAdapter;
          }
    
          crtNetworkAdapter.InvokeMethod(strOperation, null);
    
          Thread.Sleep(500);
          while (GetNetEnabled() != ((strOperation.Trim() == "Enable")
                                        ? (int)EnumNetEnabledStatus.Enabled
                                        : (int)EnumNetEnabledStatus.Disabled))
          {
             Thread.Sleep(100);
          }
    
          resultEnableDisableNetworkAdapter =
             (int)EnumEnableDisableResult.Success;
       }
       catch (NullReferenceException)
       {
          // If there is a NullReferenceException, the result of the enable or  
          // disable network adapter operation will be fail 
          resultEnableDisableNetworkAdapter = (int)EnumEnableDisableResult.Fail;
       }
    
       crtNetworkAdapter.Dispose();
    
       return resultEnableDisableNetworkAdapter;
    }
