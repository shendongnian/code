    public static bool HasFolderWritePermission(string destDir)
    {
       if(string.IsNullOrEmpty(destDir) || !Directory.Exists(destDir)) return false;
       try
       {
          DirectorySecurity security = Directory.GetAccessControl(destDir);
          SecurityIdentifier users = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
          foreach(AuthorizationRule rule in security.GetAccessRules(true, true, typeof(SecurityIdentifier)))
          {
        	  if(rule.IdentityReference == users)
        	  {
           	     FileSystemAccessRule rights = ((FileSystemAccessRule)rule);
        	     if(rights.AccessControlType == AccessControlType.Allow)
          	     {
       	                if(rights.FileSystemRights == (rights.FileSystemRights | FileSystemRights.Modify)) return true;
        	     }
              }
           }
           return false;
        }
        catch
        {
        	return false;
        }
    }
