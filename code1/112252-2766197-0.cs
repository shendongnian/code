    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Configuration;
    
    namespace ProxyAssembly
    {
        public class MyProxy:IWebProxy
        {
            
        
    #region IWebProxy Members
    
        ICredentials  IWebProxy.Credentials
        {
    	    get 
    	    { 
    		    return new NetworkCredential(ConfigurationSettings.AppSettings["googleProxyUser"],ConfigurationSettings.AppSettings["googleProxyPassword"],ConfigurationSettings.AppSettings["googleProxyDomain"]); 
    	    }
            set { }
    	      
        }
    
        public Uri  GetProxy(Uri destination)
        {
            return new Uri(ConfigurationSettings.AppSettings["googleProxyUrl"]);
        }
    
        public bool  IsBypassed(Uri host)
        {
            return Convert.ToBoolean(ConfigurationSettings.AppSettings["bypassProxy"]);
        }
    
    #endregion
    }
    }
