    public static string GetLocalhostFQDN()
    		{
    			string domainName = string.Empty;
    			try
    			{
    				domainName = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
    			}
    			catch
    			{
    			}
    			string fqdn = "localhost";
    			try
    			{
    				fqdn = System.Net.Dns.GetHostName();
    				if (!string.IsNullOrEmpty(domainName))
    				{
    					if (!fqdn.ToLowerInvariant().EndsWith("." + domainName.ToLowerInvariant()))
    					{
    						fqdn += "." + domainName;
    					}
    				}
    			}
    			catch
    			{
    			}
    			return fqdn;
    		}
