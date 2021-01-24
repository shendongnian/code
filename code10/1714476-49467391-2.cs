    using System.Security;
    using System.Security.Principal;
    using System.Security.AccessControl;
    string[] ItemSearchPath = new[] {
        Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
        Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
    };
    string[] itemSearchPattern = new[] { @"*.lnk", @"*.url" };
    List<string> linksList = itemSearchPath.SelectMany(sPath =>
                             itemSearchPattern.SelectMany(sPatt =>
                             {
                                 return UserHasDirectoryAccesRight(sPath)
                                        ? Directory.GetFiles(
                                                    sPath.ToString(CultureInfo.CurrentCulture),
                                                    sPatt.ToString(CultureInfo.CurrentCulture),
                                                                SearchOption.AllDirectories)
                                        : new string[] { "" };
                             })).ToList();
    private bool UserHasDirectoryAccesRight(string DirPath)
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent(false);
        AuthorizationRuleCollection dSecurity =
                Directory.GetAccessControl(DirPath, AccessControlSections.Access)
                         .GetAccessRules(true, true, typeof(SecurityIdentifier));
        bool hasRight =  dSecurity.Cast<AuthorizationRule>()
                                  .Any(x => x.IdentityReference.Value.Equals(identity.Owner.Value));
        return hasRight;
    }
