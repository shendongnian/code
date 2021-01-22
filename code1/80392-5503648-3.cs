    using System.Security.Principal;
    using System.Security.AccessControl;
    
    private static bool HasWritePermission(string FilePath)
    {
        try
        {
            FileSystemSecurity security;
            if (File.Exists(FilePath))
            {
                security = File.GetAccessControl(FilePath);
            }
            else
            {
                security = Directory.GetAccessControl(Path.GetDirectoryName(FilePath));
            }
            var rules = security.GetAccessRules(true, true, typeof(NTAccount));
            var currentuser = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool result = false;
            foreach (FileSystemAccessRule rule in rules)
            {
                if (0 == (rule.FileSystemRights &
                    (FileSystemRights.WriteData | FileSystemRights.Write)))
                {
                    continue;
                }
                if (rule.IdentityReference.Value.StartsWith("S-1-"))
                {
                    var sid = new SecurityIdentifier(rule.IdentityReference.Value);
                    if (!currentuser.IsInRole(sid))
                    {
                        continue;
                    }
                }
                else
                {
                    if (!currentuser.IsInRole(rule.IdentityReference.Value))
                    {
                        continue;
                    }
                }
                if (rule.AccessControlType == AccessControlType.Deny)
                    return false;
                if (rule.AccessControlType == AccessControlType.Allow)
                    result = true;
            }
            return result;
        }
        catch
        {
            return false;
        }
    }
