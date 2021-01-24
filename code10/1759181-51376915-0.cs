    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    ...
    ...
    var directoryInfo = new DirectoryInfo(@"C:\ProgramData\Test");
    // get the ACL of the directory
    var dirSec = directoryInfo.GetAccessControl();
    // remove inheritance, copying all entries so that they are direct ACEs
    dirSec.SetAccessRuleProtection(true, true);
    // do the operation on the directory
    directoryInfo.SetAccessControl(dirSec);
    // reread the ACL
    dirSec = directoryInfo.GetAccessControl();
    // get the well known SID for "Users"
    var sid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
    // loop through every ACE in the ACL
    foreach (FileSystemAccessRule rule in dirSec.GetAccessRules(true, false, typeof(SecurityIdentifier)))
    {
        // if the current entry is one with the identity of "Users", remove it
        if (rule.IdentityReference == sid)
            dirSec.RemoveAccessRule(rule);
    }
    // do the operation on the directory
    directoryInfo.SetAccessControl(dirSec);
