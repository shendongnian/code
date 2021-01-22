            // Define a key
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("AppName");
            key.SetValue("AppName", "Cracker");
            key.Close();
            // Retrieving data
            object keyData = Microsoft.Win32.Registry.CurrentUser.GetValue("AppName");
