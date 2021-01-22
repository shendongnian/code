    Uri website = new Uri("http://stackoverflow.com");
    System.Net.IWebProxy defaultproxy = System.Net.WebRequest.GetSystemWebProxy();
    Uri proxy = defaultproxy.GetProxy(website); //no actual connect is done
    
    if (proxy.AbsoluteUri != website.AbsoluteUri) {
    	Skybound.Gecko.GeckoPreferences.User["network.proxy.http"] = proxy.Host;
    	Skybound.Gecko.GeckoPreferences.User["network.proxy.http_port"] = proxy.Port;
    	Skybound.Gecko.GeckoPreferences.User["network.proxy.ssl"] = proxy.Host;
    	Skybound.Gecko.GeckoPreferences.User["network.proxy.ssl_port"] = proxy.Port;
    	Skybound.Gecko.GeckoPreferences.User["network.proxy.type"] = 1;
    	//0 – Direct connection, no proxy. (Default)
    	//1 – Manual proxy configuration.
    	//2 – Proxy auto-configuration (PAC).
    	//4 – Auto-detect proxy settings.
    	//5 – Use system proxy settings (Default in Linux).		
    }
