    // Get the underlying directory entry from the principal
    System.DirectoryServices.DirectoryEntry UnderlyingDirectoryObject =
         PrincipalInstance.GetUnderlyingObject() as System.DirectoryServices.DirectoryEntry;
    
    // Read the content of the 'notes' property (It's actually called info in the AD schema)
    string NotesPropertyContent = UnderlyingDirectoryObject.Properties["info"].Value;
    
    // Set the content of the 'notes' field (It's actually called info in the AD schema)
    UnderlyingDirectoryObject.Properties["info"].Value = "Some Text"
    
    // Commit changes to the directory entry
    UserDirectoryEntry.CommitChanges();
