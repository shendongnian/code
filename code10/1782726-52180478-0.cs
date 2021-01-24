    public class RegistryUtils
    {
        public static string Read(string subKey, string keyName)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(subKey, true);
    
            if (registryKey == null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey(subKey, true);
            }
    
            var keyValue = registryKey.GetValue(keyName);
            registryKey.Close();
    
            return keyValue.ToString();
        }
        public static void Write(string subKey, string keyName, string keyValue)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(subKey, true);
    
            if (registryKey == null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey(subKey, true);
            }
    
            registryKey.SetValue(keyName, keyValue);
            registryKey.Close();
        }
    }
