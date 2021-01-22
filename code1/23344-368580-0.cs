    public static bool IsRegistered(string name, string dllPath)
    {
        RegistryKey typeLibKey = Registry.ClassesRoot.OpenSubKey("TypeLib");
        foreach (string libIdKeyName in typeLibKey.GetSubKeyNames())
        {
            RegistryKey libIdKey = typeLibKey.OpenSubKey(libIdKeyName);
            foreach (string versionKeyName in libIdKey.GetSubKeyNames())
            {
                RegistryKey versionKey = libIdKey.OpenSubKey(versionKeyName);
                string regName = (string)versionKey.GetValue("");
                if (regName == name)
                {
                    foreach (string itterKeyName in versionKey.GetSubKeyNames())
                    {
                        int throwawayint;
                        if (int.TryParse(itterKeyName, out throwawayint))
                        {
                            RegistryKey itterKey = versionKey.OpenSubKey(itterKeyName);
                            string regDllPath = (string)itterKey.OpenSubKey("win32").GetValue("");
                            if (regDllPath == dllPath)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}
