    using (var adFolderObject = new DirectoryEntry())
    {
         using(var adSearcherObject = new DirectorySearcher(adFolderObject))
         {
              adSearcherObject.SearchScope = SearchScope.Subtree;
              adSearcherObject.Filter = "(&(objectClass=person)(" + userType + "=" + userName + "))";
    
              return adSearcherObject.FindOne();
         }
    }
