     //REFERENCES
     using System.DirectoryServices;
     using System.DirectoryServices.AccountManagement;
     using System.Security.Principal;
     using System.Security.AccessControl;
     //END OF REFERENCES
     //Exchange Shell Command:
     //Get-ADPermission -identity "<AD Distinguished Name>" | where {($_.ExtendedRights -like "*Send*") -and ($_.IsInherited -eq $false) -and -not ($_.User -like "NT AUTHORITY\SELF")} | Format-Table -AutoSize
     
     string groupSAMAccountName = "YOUR_GROUP_NAME";
     GroupPrincipal pGroup = GroupPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.SamAccountName, groupSAMAccountName);
     DirectoryEntry deGroup = pGroup.GetUnderlyingObject() as DirectoryEntry;
     //Extended Rights Reference - https://technet.microsoft.com/en-us/library/ff405676.aspx
     //Exchange right: allows sending mail as the mailbox.
     Guid exRight_SendAs = new Guid("{ab721a54-1e2f-11d0-9819-00aa0040529b}"); //GUID has 54
     //Exchange right: allows sending to a mailbox.
     Guid exRight_SendTo = new Guid("{ab721a55-1e2f-11d0-9819-00aa0040529b}"); //GUID has 55
     ActiveDirectorySecurity ads = deGroup.ObjectSecurity;
     AuthorizationRuleCollection rules = ads.GetAccessRules(true, true, typeof(SecurityIdentifier));
     List<ActiveDirectoryAccessRule> exRight_SendTo_Rules = new List<ActiveDirectoryAccessRule>();
     foreach (ActiveDirectoryAccessRule ar in rules)
     {
     	//Goal - get all entries that are classified as exRight_SendTo
     	if(ar.ObjectType.Equals(exRight_SendTo))
     	{
     		exRight_SendTo_Rules.Add(ar);
      	}
     }
     //This is where you would need to get all the sids of a account that it is a member of to filter down what rules apply to your account
      //You would probably want to include the Everyone SID and Authenticated Users SID as well.
      //From there you would bitwise operate each rule all over the place to determine if you actually have access granted on an account.
      //Just because an entry has ALLOW Send-As, doesn't mean that's your EFFECTIVE ACCESS... you don't know if another entry of another membership you belong to has DENY.
     foreach(ActiveDirectoryAccessRule ar in exRight_SendTo_Rules)
     {
     	string friendlyName = "";
      	try
      	{
      		friendlyName = ar.IdentityReference.Translate(typeof(NTAccount)).Value;
     	}
     	catch
     	{
      		friendlyName = "[Unable to resolve] SID " + ar.IdentityReference.Value;
	    }
        string ar_Result = string.Format(@"Identity={0}, User={1}, Deny={2}, Inherited={3}", 
                    pGroup.DistinguishedName,
                    friendlyName, 
                    (ar.AccessControlType == AccessControlType.Deny).ToString(), 
                    ar.IsInherited);
         Console.WriteLine(ar_Result);
         System.Diagnostics.Debug.WriteLine(ar_Result);
     }
