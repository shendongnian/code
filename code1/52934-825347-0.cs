    public DirctoryEntry Search(string searchTerm, string propertyName)
    {
       DirectoryEntry directoryObject = new DirectoryEntry(<pathToAD>);
             
       foreach (DirectoryEntry user in directoryObject.Children)
       {
          if (user.Properties["propertyName"].Value != null)    
             if (user.Properties["propertyName"].Value == searchTerm)
                 return user;                       
       }
       return null;
    }
