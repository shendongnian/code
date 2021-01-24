                //DirectoryEntry for OU Level
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://OU=MYOU,DC=MYDC,DC=COM");
                NTAccount account = new NTAccount("MYDC", "groupName");
                ActiveDirectoryAccessRule ruleRead = new ActiveDirectoryAccessRule(
                    account,
                    ActiveDirectoryRights.ReadProperty,
                    AccessControlType.Allow,
                    ActiveDirectorySecurityInheritance.None);
                ActiveDirectoryAccessRule ruleWrite = new ActiveDirectoryAccessRule(
                    account,
                    ActiveDirectoryRights.WriteProperty,
                    AccessControlType.Deny,
                    ActiveDirectorySecurityInheritance.None);
                if (Permission == "User shall be able to export private key from an RSA keypair")
                {
                    directoryEntry.ObjectSecurity.AddAccessRule(ruleRead);
                    directoryEntry.ObjectSecurity.AddAccessRule(ruleWrite);
                    directoryEntry.Options.SecurityMasks = SecurityMasks.Dacl;
                    directoryEntry.CommitChanges();
                    Console.WriteLine("Added Deny Access to Read & Write.");
                }
                if (Permission == "User is able to decrypt imported data")
                {
                    directoryEntry.ObjectSecurity.RemoveAccessRule(ruleRead);
                    directoryEntry.ObjectSecurity.RemoveAccessRule(ruleWrite);
                    directoryEntry.Options.SecurityMasks = SecurityMasks.Dacl;
                    directoryEntry.CommitChanges();
                    Console.WriteLine("Removed Deny Access to Read & Write.");
                }
                directoryEntry.Close();
                directoryEntry.Dispose();
