    // using Microsoft.Win32;
    private bool CheckPowerPointAutomation() {
        RegistryKey key = Registry.ClassesRoot.OpenSubKey("PowerPoint.Application", false);
        if (key != null) {
            key.Close();
            return true;
        }
        else {
            return false;
        }
    }
