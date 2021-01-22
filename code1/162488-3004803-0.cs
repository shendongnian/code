      static bool AppPoolIsShared(string appPoolName)
      {
         DirectoryEntry appPool = new DirectoryEntry(string.Format("IIS://localhost/w3svc/AppPools/{0}", appPoolName));
         if (appPool != null)
         {
            try
            {
               object[] appsInPool = (object[])appPool.Invoke("EnumAppsInPool", null);
               if (appsInPool != null && appsInPool.Length > 1)
               {
                  return true;
               }
            }
            catch
            {
               return true;
            }
         }
    
         return false;
      }
