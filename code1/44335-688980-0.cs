    using System;
    using System.DirectoryServices;
    
    namespace AcadDashBoard.Enterprise
    {
      public class AuthenicationMgr
      {
        private static readonly int AD_ERR_LOGON_FAIL = -2147023570;
        private static readonly string _path = "LDAP://xxx.yyy.ggg";
        private static readonly string _domain = "xxx.yyy.ggg";
    
        public static bool IsAuthenticated(string username, string pwd)
        {
          bool authenticatedFlag = true;
          string domainAndUsername = _domain + "\\" + username;
          DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
          try
          {
            // Bind to the native AdsObject to force authentication.
            Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
    
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
    
            if (result == null)
            {
              authenticatedFlag = false;
            }
            else
            {
              authenticatedFlag = true;
            }
          }
          catch (System.Runtime.InteropServices.COMException ex)
          {
            if (ex.ErrorCode == AD_ERR_LOGON_FAIL)
            {
              authenticatedFlag = false;
            }
            else
            {
              throw new ApplicationException("Unable to authenticate user due to system error.", ex);
            }
          }
          return authenticatedFlag;
        }
      }
    }
