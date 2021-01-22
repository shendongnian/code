    string strPath = "OU=Test1,OU=Test2,OU=Test3,DC=Internal,DC=net";
    // get just DC portion of distinguished name
    int dcIndex = strPath.IndexOf("DC=");
    string dcSubString = strPath.Substring(dcIndex);
    // get just OU portion of distinguished name
    string ouSubString = strPath.Substring(0, dcIndex -1);
    string tempDistinguishedName = dcSubString;
    string[] ouSubStrings = ouSubString.Split(','); 
    for (int i = ouSubStrings.Length - 1; i >= 0; i--)
    {
        // bind
        DirectoryEntry directoryEntry = new DirectoryEntry(tempDistinguishedName);
        // Create OU
        directoryEntry.Children.Add(ouSubStrings[i], "OrganizationalUnit");
        directoryEntry.CommitChanges();
        // create distinguishedName for next bind        
        tempDistinguishedName = ouSubStrings[i] + "," + tempDistinguishedName;
        directoryEntry.Dispose(); // clean up unmanaged resources
    }
