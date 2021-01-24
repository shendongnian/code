        RegistryKey baseRegistryKey = RegistryKey.OpenBaseKey(baseKey, RegistryView.Registry64);
        RegistryKey subRegistryKey = baseRegistryKey.OpenSubKey(subKey, RegistryKeyPermissionCheck.ReadSubTree);
        if (subRegistryKey != null)
        {
            object value64 = subRegistryKey.GetValue(value);
            if (value64 != null)
            {
                baseRegistryKey.Close();
                subRegistryKey.Close();
                return value64;
            }
            subRegistryKey.Close();
        }            
        baseRegistryKey.Close();
