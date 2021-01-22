    public bool RemoveUserFromGroup(string UserName, string GroupName)
    {
       bool lResult = false;
       if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(GroupName)) return lResult;
       try
       {
          using (DirectoryEntry dirEntry = GetDirectoryEntry())
          {
             using (DirectoryEntry dirUser = GetUser(UserName))
             {
                if (dirEntry == null || dirUser == null)
                {
                   return lResult;
                }
                using (DirectorySearcher deSearch = new DirectorySearcher())
                {
                   deSearch.SearchRoot = dirEntry;
                   deSearch.Filter = String.Format("(&(objectClass=group) (cn={0}))", GroupName);
                   deSearch.PageSize = 1000;
                   SearchResultCollection result = deSearch.FindAll();
                   bool isAlreadyRemoved = false;
                   String sDN = dirUser.Path.Replace("LDAP://", String.Empty);
                   if (result != null && result.Count > 0)
                   {
                      for (int i = 0; i < result.Count; i++)
                      {
                         using (DirectoryEntry dirGroup = result[i].GetDirectoryEntry())
                         {
                            String sGrDN = dirGroup.Path.Replace("LDAP://", String.Empty);
                            if (dirUser.Properties[Constants.Properties.PROP_MEMBER_OF].Contains(sGrDN))
                            {
                               dirGroup.Properties[Constants.Properties.PROP_MEMBER].Remove(sDN);
                               dirGroup.CommitChanges();
                               dirGroup.Close();
                               lResult = true;
                               isAlreadyRemoved = true;
                               break;
                            }
                         }
                         if (isAlreadyRemoved)
                            break;
                      }
                   }
                }
             }
          }
       }
       catch
       {
          lResult= false;
       }
       return lResult;
    }
