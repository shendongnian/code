    string path = @"c:\temp";
    string NtAccountName = @"MyDomain\MyUserOrGroup";
    
    DirectoryInfo di = new DirectoryInfo(path);
    DirectorySecurity acl = di.GetAccessControl(AccessControlSections.All);
    AuthorizationRuleCollection rules = acl.GetAccessRules(true, true, typeof(NTAccount));
    
    //Go through the rules returned from the DirectorySecurity
    foreach (AuthorizationRule rule in rules)
    {
        //If we find one that matches the identity we are looking for
        if (rule.IdentityReference.Value.Equals(NtAccountName,StringComparison.CurrentCultureIgnoreCase))
        {
    		var filesystemAccessRule = (FileSystemAccessRule)rule;
    		
            //Cast to a FileSystemAccessRule to check for access rights
            if ((filesystemAccessRule.FileSystemRights & FileSystemRights.WriteData)>0 && filesystemAccessRule.AccessControlType != AccessControlType.Deny)
            {
                Console.WriteLine(string.Format("{0} has write access to {1}", NtAccountName, path));
            }
            else
            {
                Console.WriteLine(string.Format("{0} does not have write access to {1}", NtAccountName, path));
            }
        }
    }
    
    Console.ReadLine();
