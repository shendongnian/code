    static class ComACLRights{
        public const int COM_RIGHTS_EXECUTE= 1;
        public const int COM_RIGHTS_EXECUTE_LOCAL = 2;
        public const int COM_RIGHTS_EXECUTE_REMOTE = 4;
        public const int COM_RIGHTS_ACTIVATE_LOCAL = 8;
        public const int COM_RIGHTS_ACTIVATE_REMOTE = 16;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", "DefaultAccessPermission", null);
            RawSecurityDescriptor sd;
            RawAcl acl;
            
            if (value == null)
            {
                System.Console.WriteLine("Default Access Permission key has not been created yet");
                sd = new RawSecurityDescriptor("");
            }else{
                sd = new RawSecurityDescriptor(value as byte[], 0);
            }
            acl = sd.DiscretionaryAcl;
            bool found = false;
            foreach (CommonAce ca in acl)
            {
                if (ca.SecurityIdentifier.IsWellKnown(WellKnownSidType.NetworkServiceSid))
                {
                    //ensure local access is set
                    ca.AccessMask |= ComACLRights.COM_RIGHTS_EXECUTE | ComACLRights.COM_RIGHTS_EXECUTE_LOCAL | ComACLRights.COM_RIGHTS_ACTIVATE_LOCAL;    //set local access.  Always set execute
                    found = true;
                    break;
                }
            }
            if(!found){
                //Network Service was not found.  Add it to the ACL
                SecurityIdentifier si = new SecurityIdentifier( 
                    WellKnownSidType.NetworkServiceSid, null);
                CommonAce ca = new CommonAce(
                    AceFlags.None, 
                    AceQualifier.AccessAllowed, 
                    ComACLRights.COM_RIGHTS_EXECUTE | ComACLRights.COM_RIGHTS_EXECUTE_LOCAL | ComACLRights.COM_RIGHTS_ACTIVATE_LOCAL, 
                    si, 
                    false, 
                    null);
                acl.InsertAce(acl.Count, ca);
            }
            //re-set the ACL
            sd.DiscretionaryAcl = acl;
            byte[] binaryform = new byte[sd.BinaryLength];
            sd.GetBinaryForm(binaryform, 0);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", "DefaultAccessPermission", binaryform, RegistryValueKind.Binary);
        }
    }
