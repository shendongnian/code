    string[] ItemSearchPath = new[] {
        Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
        Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
    };
    string[] ItemSearchPattern = new[] { @"*.lnk", @"*.url" };
    List<string> _LinksList = ItemSearchPath.SelectMany(x =>
                              ItemSearchPattern.SelectMany(y => 
                              {
                                  return UserHasDirectoryAccesRight(x)
                                          ? Directory.GetFiles(
                                                    x.ToString(CultureInfo.CurrentCulture), 
                                                    y.ToString(CultureInfo.CurrentCulture), 
                                                               SearchOption.AllDirectories) 
                                          : new string[] { "" }; 
                              } ))
                              .ToList();
    using System.Security;
    using System.Security.Principal;
    using System.Security.AccessControl;
    private bool UserHasDirectoryAccesRight(string DirPath)
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent(false);
        AuthorizationRuleCollection dSecurity =
                Directory.GetAccessControl(DirPath, AccessControlSections.Access)
                         .GetAccessRules(true, false, typeof(SecurityIdentifier));
        return dSecurity.Cast<AuthorizationRule>()
                        .Any(x => x.IdentityReference.Value == identity.Owner.Value);
    }
