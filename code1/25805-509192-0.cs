    String strOUs = container.Substring(0, container.IndexOf(@",DC="));
    int dcIndex = container.IndexOf("DC=");
    string dcSubString = container.Substring(dcIndex); //dcSubString = DC=Internal,DC=Net
    string[] strOUArray = strOUs.Split(new Char[] { ',' });
    
    // create a bind path which we'll build up
    string ldapPath = dcSubString;
    
    // bind to the top-level container
    DirectoryEntry workEntry = new DirectoryEntry("LDAP://" + ldapPath);
    
    // loop through all sub-OU's to create
    foreach(string currentOU in strOUArray)
    {
      // add the next OU below the current entry
      objOU = workEntry.Children.Add(currentOU, "OrganizationalUnit");
      objOU.CommitChanges(); 
      
      // bind to the newly created OU
      ldapPath = currentOU + "," + ldapPath;
      workEntry = new DirectoryEntry("LDAP://" + ldapPath);
    }
     
