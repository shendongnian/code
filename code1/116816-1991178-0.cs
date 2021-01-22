    // using Microsoft.Win32;
    private bool CheckPowerPointAssociation() {
        RegistryKey key = Registry.ClassesRoot.OpenSubKey(".ppt", false);
        if (key != null) {
            key.Close();
            return true;
        }
        else {
            return false;
        }
    }
