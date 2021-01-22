        private void determineNumberOfProcessCores()
        {
            RegistryKey rk = Registry.LocalMachine;
            String[] subKeys = rk.OpenSubKey("HARDWARE").OpenSubKey("DESCRIPTION").OpenSubKey("System").OpenSubKey("CentralProcessor").GetSubKeyNames();
            textBox1.Text = "Total number of cores:" + subKeys.Length.ToString();
        }
