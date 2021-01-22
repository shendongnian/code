    // using Microsoft.Win32;
    private bool CheckPowerPointAssociation() {
        var key = Registry.ClassesRoot.OpenSubKey(".ppt", false);
        if (key != null) {
            key.Close();
            return true;
        }
        else {
            return false;
        }
    }
    
    if (CheckPowerPointAssociation()) {
        Process.Start(pathToPPT);
    }
