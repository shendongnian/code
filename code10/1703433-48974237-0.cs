        static string GetUniqueID()
        {
            string result;
            string registry_path = "HKEY_CURRENT_USER\\Software\\MyApp";  // substitue your own app name here
            Object obj = Registry.GetValue(registry_path, "UniqueID", null);
            if ((obj == null) || !(obj is string))
            {
                result = Guid.NewGuid().ToString();
                Registry.SetValue(registry_path, "UniqueID", result);
            }
            else
            {
                result = (string)obj;
            }
            return result;
        }
