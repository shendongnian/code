    using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"))
        if (Key != null)
        {    
            string val = Key.GetValue("COMODO Internet Security");
            if (val == null)
            {
                MessageBox.Show("value not found");
            }
            else
            {
                // use the value
            }
        }
        else
        {
            MessageBox.Show("key not found");
        }
