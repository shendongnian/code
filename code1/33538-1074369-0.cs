    public static void DeleteSubKeyTree(this RegistryKey key, string subkey, 
        bool throwOnMissingSubKey)
    {
        if (!throwOnMissingSubKey && key.OpenSubKey(subkey) == null) { return; }
        key.DeleteSubKeyTree(subkey);
    }
