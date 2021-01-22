        using System.DirectoryServices;
        //srvr = ldap server, e.g. LDAP://domain.com
        //usr = user name
        //pwd = user password
        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;
            
            try
            {
                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
                authenticated = true;
            }
            catch (DirectoryServicesCOMException cex)
            {
                //not authenticated; reason why is in cex
            }
            return authenticated;
        }
