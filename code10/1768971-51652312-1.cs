    [assembly: Dependency(typeof(YourAppNamespace.Android.Android.DependencyServices.IPAddressManager))]
    
    namespace YourAppNamespace.Android.Android.DependencyServices
    {
        class IPAddressManager : IIPAddressManager
        {
            public string GetIPAddress()
            {
                IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());
    
                if (adresses !=null && adresses[0] != null)
                {
                    return adresses[0].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
    }
