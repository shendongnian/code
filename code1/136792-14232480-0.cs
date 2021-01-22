            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(Regname);
                key.SetValue(Key, value);
                key.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public string readRegistryKey(string Value)
        {
            try
            {
                string keyValue = null;
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(Regname);
                keyValue = key.GetValue(id).ToString();
                key.Close();
                return keyValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        } 
