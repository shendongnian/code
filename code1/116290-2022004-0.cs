    void AddPictureToUser(
        string strDN,       // User Distinguished Name, in the form "CN=Joe User,OU=Employees,DC=company,DC=local"
        string strDCName,   // Domain Controller, ie: "DC-01"
        string strFileName // Picture file to open and import into AD
        )
    {
        // Open file
        System.IO.FileStream inFile = new System.IO.FileStream(strFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        // Retrive Data into a byte array variable
        byte[] binaryData = new byte[inFile.Length];
        int bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
        inFile.Close();
        // Connect to AD
        System.DirectoryServices.DirectoryEntry myUser = new System.DirectoryServices.DirectoryEntry(@"LDAP://" + strDCName + @"/" + strDN);
        // Clear existing picture if exists
        myUser.Properties["jpegPhoto"].Clear();
        // Update attribute with binary data from file
        myUser.Properties["jpegPhoto"].Add(binaryData);
        myUser.CommitChanges();
    }
