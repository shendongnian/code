    SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
    NTAccount account = sid.Translate(typeof(NTAccount)) as NTAccount;
    // Get ACL from Windows
    // CHANGED to open the key as writable: using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(key))
    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree))
    {
            // CHANGED to add to existing security: RegistrySecurity rs = new RegistrySecurity();
        RegistrySecurity rs = rk.GetAccessControl()
        // Creating registry access rule for 'Everyone' NT account
        RegistryAccessRule rar = new RegistryAccessRule(
            account.ToString(),
            RegistryRights.FullControl,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            PropagationFlags.None,
            AccessControlType.Allow);
        rs.AddAccessRule(rar);
        rk.SetAccessControl(rs);
    }
