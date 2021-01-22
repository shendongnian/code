    [ComVisible(false)]
    public unsafe RegistryKey CreateSubKey(string subkey, RegistryKeyPermissionCheck permissionCheck, RegistrySecurity registrySecurity)
    {
        ValidateKeyName(subkey);
        ValidateKeyMode(permissionCheck);
        this.EnsureWriteable();
        subkey = FixupName(subkey);
        if (!this.remoteKey)
        {
            RegistryKey key = this.InternalOpenSubKey(subkey, permissionCheck != RegistryKeyPermissionCheck.ReadSubTree);
            if (key != null)
            {
                this.CheckSubKeyWritePermission(subkey);
                this.CheckSubTreePermission(subkey, permissionCheck);
                key.checkMode = permissionCheck;
                return key;
            }
        }
        this.CheckSubKeyCreatePermission(subkey);
        Win32Native.SECURITY_ATTRIBUTES structure = null;
        if (registrySecurity != null)
        {
            structure = new Win32Native.SECURITY_ATTRIBUTES();
            structure.nLength = Marshal.SizeOf(structure);
            byte[] securityDescriptorBinaryForm = registrySecurity.GetSecurityDescriptorBinaryForm();
            byte* pDest = stackalloc byte[1 * securityDescriptorBinaryForm.Length];
            Buffer.memcpy(securityDescriptorBinaryForm, 0, pDest, 0, securityDescriptorBinaryForm.Length);
            structure.pSecurityDescriptor = pDest;
        }
        int lpdwDisposition = 0;
        SafeRegistryHandle hkResult = null;
        int errorCode = Win32Native.RegCreateKeyEx(this.hkey, subkey, 0, null, 0, GetRegistryKeyAccess(permissionCheck != RegistryKeyPermissionCheck.ReadSubTree), structure, out hkResult, out lpdwDisposition);
        if ((errorCode == 0) && !hkResult.IsInvalid)
        {
            RegistryKey key2 = new RegistryKey(hkResult, permissionCheck != RegistryKeyPermissionCheck.ReadSubTree, false, this.remoteKey, false);
            this.CheckSubTreePermission(subkey, permissionCheck);
            key2.checkMode = permissionCheck;
            if (subkey.Length == 0)
            {
                key2.keyName = this.keyName;
                return key2;
            }
            key2.keyName = this.keyName + @"\" + subkey;
            return key2;
        }
        if (errorCode != 0)
        {
            this.Win32Error(errorCode, this.keyName + @"\" + subkey);
        }
        return null;
    }
