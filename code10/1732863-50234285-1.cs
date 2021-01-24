    try
    {
        var wifiManager = context.GetSystemService(Context.WifiService) as WifiManager;
        if (!wifiManager.IsWifiEnabled)
            return;
    
        var configurationList = wifiManager.ConfiguredNetworks;
    
        var cur = wifiManager.ConnectionInfo.NetworkId;
        var configuration = configurationList.FirstOrDefault(conf => conf.NetworkId == cur);
    
        Class proxyInfoClass = Class.ForName("android.net.ProxyInfo");
        Class[] setHttpProxyParams = new Class[1];
        setHttpProxyParams[0] = proxyInfoClass;
        Class wifiConfigClass = Class.ForName("android.net.wifi.WifiConfiguration");
        Method setHttpProxy = wifiConfigClass.GetDeclaredMethod("setHttpProxy", setHttpProxyParams);
        setHttpProxy.Accessible = true;
    
        //Method 1 to get the ENUM ProxySettings in IpConfiguration
        Class ipConfigClass = Class.ForName("android.net.IpConfiguration");
        Field f = ipConfigClass.GetField("proxySettings");
        Class proxySettingsClass = f.Type;
    
        //Method 2 to get the ENUM ProxySettings in IpConfiguration
        //Note the $ between the class and ENUM
        //Class proxySettingsClass = Class.forName("android.net.IpConfiguration$ProxySettings");
    
        Class[] setProxySettingsParams = new Class[1];
        setProxySettingsParams[0] = proxySettingsClass;
        Method setProxySettings = wifiConfigClass.GetDeclaredMethod("setProxySettings", setProxySettingsParams);
        setProxySettings.Accessible = true;
    
    
        ProxyInfo pi = ProxyInfo.BuildDirectProxy(proxyServerAddress, proxyServerPort);
        //Android 5 supports a PAC file
        //ENUM value is "PAC"
        //ProxyInfo pacInfo = ProxyInfo.buildPacProxy(Uri.parse("http://localhost/pac"));
    
        //pass the new object to setHttpProxy
        Java.Lang.Object[] params_SetHttpProxy = new Java.Lang.Object[1];
        params_SetHttpProxy[0] = pi;
        setHttpProxy.Invoke(configuration, params_SetHttpProxy);
    
        //pass the enum to setProxySettings
        Java.Lang.Object[] params_setProxySettings = new Java.Lang.Object[1];
        params_setProxySettings[0] = Java.Lang.Enum.ValueOf(proxySettingsClass, "STATIC");
        setProxySettings.Invoke(configuration, params_setProxySettings);
    
        //save the settings
        var networkId = wifiManager.UpdateNetwork(configuration);
        wifiManager.Disconnect();
        wifiManager.EnableNetwork(networkId, true);
        wifiManager.Reconnect();
    
        var m_Manager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
    
        while (!m_Manager.GetNetworkInfo(ConnectivityType.Wifi).IsConnected);
    }
    catch (Exception e)
    {
        throw;
    }
