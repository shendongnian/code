    // using Microsoft.Win32;
    private bool CheckPowerPointAutomation() {
        var key = Registry.ClassesRoot.OpenSubKey("PowerPoint.Application", false);
        if (key != null) {
            key.Close();
            return true;
        }
        else {
            return false;
        }
    }
    
    if (CheckPowerPointAutomation()) {
        var powerPointApp = new Microsoft.Office.Interop.PowerPoint.Application();
        ....
    }
