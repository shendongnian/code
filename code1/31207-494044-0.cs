    using System.DirectoryServices;
    
    public static string GetFullName(string strLogin)
        {
            string str = "";
            string strDomain;
            string strName;
    
            // Parse the string to check if domain name is present.
            int idx = strLogin.IndexOf('\\');
            if (idx == -1)
            {
                idx = strLogin.IndexOf('@');
            }
    
            if (idx != -1)
            {
                strDomain = strLogin.Substring(0, idx);
                strName = strLogin.Substring(idx + 1);
            }
            else
            {
                strDomain = Environment.MachineName;
                strName = strLogin;
            }
    
            DirectoryEntry obDirEntry = null;
            try
            {
                obDirEntry = new DirectoryEntry("WinNT://" + strDomain + "/" + strName);
                System.DirectoryServices.PropertyCollection coll = obDirEntry.Properties;
                object obVal = coll["FullName"].Value;
                str = obVal.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
