    // These are constants for the access mask on LaunchPermission.
    // I'm unsure of the exact constants for AccessPermission
    private const int COM_RIGHTS_EXECUTE = 1;
    private const int COM_RIGHTS_EXECUTE_LOCAL = 2;
    private const int COM_RIGHTS_EXECUTE_REMOTE = 4;
    private const int COM_RIGHTS_ACTIVATE_LOCAL = 8;
    private const int COM_RIGHTS_ACTIVATE_REMOTE = 16;
    void EditOrCreateACE(string keyname, string valuename,
                          string accountname, int mask)
    {
        // Get security descriptor from registry
        byte[] keyval = (byte[]) Registry.GetValue(keyname, valuename,
                                                   new byte[] { });
        RawSecurityDescriptor sd;
        if (keyval.Length > 0) {
            sd = new RawSecurityDescriptor(keyval, 0);
        } else {
            sd = InitializeEmptySecurityDescriptor();
        }
        RawAcl acl = sd.DiscretionaryAcl;
        CommonAce accountACE = null;
        // Look for the account in the ACL
        int i = 0;
        foreach (GenericAce ace in acl) {
            if (ace.AceType == AceType.AccessAllowed) {
                CommonAce c_ace = ace as CommonAce;
                NTAccount account = 
                    c_ace.SecurityIdentifier.Translate(typeof(NTAccount))
                    as NTAccount;
                if (account.Value.Contains(accountname)) {
                    accountACE = c_ace;
                }
                i++;
            }
        }
        // If no ACE found for the given account, insert a new one at the end
        // of the ACL, otherwise just set the mask
        if (accountACE == null) {
            SecurityIdentifier ns_account = 
                (new NTAccount(accountname)).Translate(typeof(SecurityIdentifier))
                as SecurityIdentifier;
            CommonAce ns = new CommonAce(AceFlags.None, AceQualifier.AccessAllowed,
                                         mask, ns_account, false, null);
            acl.InsertAce(acl.Count, ns);
        } else {
            accountACE.AccessMask |= mask;
        }
        // Write security descriptor back to registry
        byte[] binarySd = new byte[sd.BinaryLength];
        sd.GetBinaryForm(binarySd, 0);
        Registry.SetValue(keyname, valuename, binarySd);
    }
    private static RawSecurityDescriptor InitializeEmptySecurityDescriptor()
    {
        var localSystem = 
            new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null);
        var new_sd =
            new RawSecurityDescriptor(ControlFlags.DiscretionaryAclPresent,
                                      localSystem, localSystem, null,
                                      new RawAcl(GenericAcl.AclRevision, 1));
        return new_sd;
    }
