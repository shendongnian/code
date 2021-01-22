    // get the existing access controls
    FileSecurity fs = File.GetAccessControl(yourFilename);
    // add the new rule to the existing settings
    fs.AddAccessRule(new FileSystemAccessRule(
        @"DOMAIN\Users",  // or "BUILTIN\Users", "COMPUTER\AccountName" etc
        FileSystemRights.Modify,
        AccessControlType.Allow));
    // set the updated access controls
    File.SetAccessControl(yourFilename, fs);
