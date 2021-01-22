          public static DirectoryEntry GetDirectoryObject(string strPath)
            {
                if (strPath == "")
                {
                    strPath = ConfigurationManager.AppSettings["LDAPPath"]; //YOUR DEFAULT LDAP PATH ie. LDAP://YourDomainServer
                }
        
                string username = ConfigurationManager.AppSettings["LDAPAccount"];
                string password = ConfigurationManager.AppSettings["LDAPPassword"];
                    //You can encrypt and decrypt your password settings in web.config, but for the sake of simplicity, I've excluded the encryption code from this listing.
                
    }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("user: " + username + ", LDAPAccount: "+ ConfigurationManager.AppSettings["LDAPAccount"] + ".<br /> "+ ex.Message +"<br />");
        
                    if (HttpContext.Current.User.Identity != null)
                    {
                        
                        HttpContext.Current.Response.Write("HttpContext.Current.User.Identity: " + HttpContext.Current.User.Identity.Name + ", " + HttpContext.Current.User.Identity.IsAuthenticated.ToString() + "<br />");
        
                        HttpContext.Current.Response.Write("Windows Identity: " + WindowsIdentity.GetCurrent().Name + ", " + HttpContext.Current.User.Identity.IsAuthenticated.ToString());
        
        
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("User.Identity is null.");
                    }
                    
                    HttpContext.Current.Response.End();
        
        
                }
                
                
        
              
                DirectoryEntry oDE = new DirectoryEntry(strPath, username, password, AuthenticationTypes.Secure);
                return oDE;
            }
     public static string GetNetBIOSName(string DomainName)
     {
    
    
    
         string netBIOSName = "";
         DirectoryEntry rootDSE =GetDirectoryObject(
             "LDAP://"+DomainName+"/rootDSE");
    
         string domain = (string)rootDSE.Properties[
             "defaultNamingContext"][0];
    
          //   netBIOSName += "Naming Context: " + domain + "<br />";
    
        if (!String.IsNullOrEmpty(domain))
         {
             DirectoryEntry parts = GetDirectoryObject(
                 "LDAP://"+DomainName+"/CN=Partitions, CN=Configuration," + domain);
    
                foreach (DirectoryEntry part in parts.Children)
             {
                    
    
                 if ((string)part.Properties[
                     "nCName"][0] == domain)
                 {
                     netBIOSName +=  (string)part.Properties[
                         "NetBIOSName"][0];
                     break;
                 }
             }
    
          
         } 
            return netBIOSName;
     }
        public static string GetDomainUsernameFromUPN(string strUPN)
    {
    string DomainName;
    string UserName;
      if (strUPN.Contains("@"))
            {
                string[] ud = strUPN.Split('@');
                strUPN= ud[0];
                DomainName = ud[1];
    
                DomainName=LDAPToolKit.GetNetBIOSName(DomainName);
    
                UserName= DomainName + "\\" + strUPN;
            }
            else
            {
                UserName= strUPN;
            }
    
    
        return UserName;
    }
