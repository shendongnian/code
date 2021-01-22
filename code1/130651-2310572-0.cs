    FileInfo fi = new FileInfo(myTargetFile);
    var acl = fi.GetAccessControl();
    var rules = acl.GetAccessRules(true, true, typeof(SecurityIdentifier));
    
    //Remove all existing permissions on the file
    foreach (var rule in rules.Cast<FileSystemAccessRule>())
    {
      acl.RemoveAccessRule(rule);
    }
    
    //Allow inherited permissions on the file
    acl.SetAccessRuleProtection(false, false);
    fi.SetAccessControl(acl);
